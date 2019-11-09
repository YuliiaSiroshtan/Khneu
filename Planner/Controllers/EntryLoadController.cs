using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Planner.Entities.DTO;
using Planner.PresentationLayer.ViewModels;
using Planner.ServiceInterfaces.Interfaces;

namespace Planner.Controllers
{
  [Route("api/[controller]")]
  public class EntryLoadController : GenericController
  {
    private readonly IWebHostEnvironment _hostingEnvironment;
    private IEnumerable<FacultyDto> _faculties;
    private IEnumerable<DepartmentDto> _departments;

    public EntryLoadController(IServiceFactory serviceFactory,
      IMapper mapper,
      IWebHostEnvironment hostingEnvironment) : base(serviceFactory, mapper)
    {
      _hostingEnvironment = hostingEnvironment;
    }


    [HttpGet("[action]")]
    public async Task<IActionResult> GetEntryLoadProperties()
    {
      var entryLoadsProperties = await ServiceFactory.EntryLoadsPropertyService.GetEntryLoadsProperties();
      var entryLoadsPropertiesViewModel = Mapper.Map<IEnumerable<EntryLoadsPropertyViewModel>>(entryLoadsProperties);

      return Ok(entryLoadsPropertiesViewModel);
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> UpdateEntryLoadFile(int id)
    {
      var entryLoadsProperties = await ServiceFactory.EntryLoadsPropertyService.GetEntryLoadsProperties();

      var entryLoadsProperty = entryLoadsProperties.Single(x => x.Id == id);
      var entryLoadsPropertyIsActive = entryLoadsProperties.Single(x => x.IsActive);

      entryLoadsPropertyIsActive.IsActive = false;
      await ServiceFactory.EntryLoadsPropertyService.UpdateEntryLoadsProperty(entryLoadsPropertyIsActive);

      entryLoadsProperty.IsActive = true;
      await ServiceFactory.EntryLoadsPropertyService.UpdateEntryLoadsProperty(entryLoadsProperty);

      await GetFacultiesAndDepartmentsData();
      await ServiceFactory.EntryLoadsPropertyService.RecreateTables();

      var path = Path.Combine(_hostingEnvironment.WebRootPath, "EntryLoadsFiles", entryLoadsProperty.Name);

      try
      {
        await ReadFullTimeData(path);
        await ReadPartTimeData(path);
      }
      catch (Exception e)
      {
        BadRequest(e.Message);
      }

      return Ok(entryLoadsProperty);

    }

    [HttpPost("[action]")]
    public async Task<IActionResult> DeleteEntryLoadFile(int id)
    {
      var entryLoadsProperty = await ServiceFactory.EntryLoadsPropertyService.GetEntryLoadsPropertyById(id);

      var path = Path.Combine(_hostingEnvironment.WebRootPath, "EntryLoadsFiles", entryLoadsProperty.Name);

      if (System.IO.File.Exists(path))
      {
        System.IO.File.Delete(path);

        await ServiceFactory.EntryLoadsPropertyService.DeleteEntryLoadsProperty(id);

        return Ok("Файл видалено з серверу");
      }

      return BadRequest("Файл не знайдено");
    }


    [HttpPost, DisableRequestSizeLimit]
    public async Task<IActionResult> UploadFile([FromForm] FileInfoModel fileInfo)
    {
      const string folderName = "EntryLoadsFiles";

      var fileName = DateTime.Now.GetHashCode().ToString();

      try
      {
        var path = Path.Combine(_hostingEnvironment.WebRootPath, folderName);

        if (!Directory.Exists(path))
        {
          Directory.CreateDirectory(path);
        }

        if (fileInfo.File.Length > 0)
        {
          var fullPath = Path.Combine(path, fileName);

          await using var stream = new FileStream(fullPath, FileMode.Create);
          await fileInfo.File.CopyToAsync(stream);

          await InsertEntryLoadsPropertyData(fileInfo.HoursPerRate, fileName);

          return Json(fullPath);
        }
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }

      return BadRequest("Помилка завантаження файлу");
    }

    #region private methods

    private async Task ReadFullTimeData(string path)
    {
      var excel = new ExcelParser.ExcelParser(path, 1);

      for (var i = 6; i <= excel.Count; i++)
      {
        var entryLoadData = excel.ReadRange($"A{i}", $"N{i}");
        var disciplineData = excel.ReadRange($"O{i}", $"T{i}");
        var firstSemesterData = excel.ReadRange($"U{i}", $"AC{i}");
        var secondSemesterData = excel.ReadRange($"AD{i}", $"AL{i}");
        var codeDepartmentData = excel.ReadRange($"AM{i}", $"AN{i}");

        var firstSemester = GetFirstSemesterData(firstSemesterData);
        var secondSemester = GetSecondSemesterData(secondSemesterData);
        var discipline = GetDisciplineData(disciplineData, firstSemester, secondSemester, codeDepartmentData);
        var entryLoad = GetFullEntryLoadData(entryLoadData, discipline);

        await InsertData(firstSemester, secondSemester, discipline, entryLoad);
      }

      excel.Close();
    }

    private async Task ReadPartTimeData(string path)
    {
      var excel = new ExcelParser.ExcelParser(path, 2);

      for (var i = 6; i < excel.Count; i++)
      {
        var entryLoadData = excel.ReadRange($"A{i}", $"L{i}");
        var disciplineData = excel.ReadRange($"M{i}", $"R{i}");
        var constituentSessionData = excel.ReadRange($"S{i}", $"AB{i}");
        var examinationSessionData = excel.ReadRange($"AC{i}", $"AL{i}");
        var codeDepartmentData = excel.ReadRange($"AM{i}", $"AN{i}");

        var constituentSession = GetConstituentSessionData(constituentSessionData);
        var examinationSession = GetExaminationSessionData(examinationSessionData);
        var discipline = GetPartTimeDisciplineData(disciplineData, constituentSession, examinationSession, codeDepartmentData);
        var entryLoad = GetPartTimeEntryLoadData(entryLoadData, discipline);

        await InsertData(constituentSession, examinationSession, discipline, entryLoad);

      }

      excel.Close();
    }

    private static PartTimeEntryLoadDto GetPartTimeEntryLoadData(object[,] entryLoadData, PartTimeDisciplineDto discipline)
    {
      return new PartTimeEntryLoadDto
      {
        Unit = entryLoadData[1, 1]?.ToString(),
        Specialty = entryLoadData[1, 2]?.ToString(),
        Specialization = entryLoadData[1, 3]?.ToString(),
        Course = entryLoadData[1, 4]?.ToString(),
        EducationalDegree = entryLoadData[1, 5]?.ToString(),
        AmountOfStudents = entryLoadData[1, 6]?.ToString(),
        NumberOfGroups = entryLoadData[1, 7]?.ToString(),
        AmountOfStudentsStreams = entryLoadData[1, 8]?.ToString(),
        ConnectingOfStudentStreams = entryLoadData[1, 9]?.ToString(),
        MainSpecial = entryLoadData[1, 10]?.ToString(),
        NumberOfConstituentSession = entryLoadData[1, 11]?.ToString(),
        NumberOfExaminationSession = entryLoadData[1, 12]?.ToString(),
        PartTimeDiscipline = discipline
      };
    }

    private PartTimeDisciplineDto GetPartTimeDisciplineData(object[,] disciplineData, ConstituentSessionDto constituentSession,
      ExaminationSessionDto examinationSession, object[,] codeDepartmentData)
    {
      return new PartTimeDisciplineDto
      {
        Name = disciplineData[1, 1]?.ToString(),
        ECTS = disciplineData[1, 2]?.ToString(),
        AmountOfHours = disciplineData[1, 3]?.ToString(),
        KRKPDR = disciplineData[1, 4]?.ToString(),
        Language = disciplineData[1, 5]?.ToString(),
        NumberOfDeaneryMembers = disciplineData[1, 6]?.ToString(),
        ConstituentSession = constituentSession.Hours == null ? null : constituentSession,
        ExaminationSession = examinationSession.Hours == null ? null : examinationSession,
        Department = _departments.SingleOrDefault(d => d.CodeDepartment.Equals(codeDepartmentData[1, 1]?.ToString().ToLower()))
      };
    }

    private static ConstituentSessionDto GetConstituentSessionData(object[,] constituentSessionData)
    {
      return new ConstituentSessionDto
      {
        Hours = constituentSessionData[1, 1]?.ToString(),
        HoursAll = constituentSessionData[1, 2]?.ToString(),
        Lectures = constituentSessionData[1, 3]?.ToString(),
        Laboratory = constituentSessionData[1, 4]?.ToString(),
        Practical = constituentSessionData[1, 5]?.ToString(),
        IndividualWork = constituentSessionData[1, 6]?.ToString(),
        CourseWork = constituentSessionData[1, 7]?.ToString(),
        ControlWork = constituentSessionData[1, 8]?.ToString(),
        Exam = constituentSessionData[1, 9]?.ToString(),
        Credit = constituentSessionData[1, 10]?.ToString()
      };
    }

    private static ExaminationSessionDto GetExaminationSessionData(object[,] examinationSessionData)
    {
      return new ExaminationSessionDto()
      {
        Hours = examinationSessionData[1, 1]?.ToString(),
        HoursAll = examinationSessionData[1, 2]?.ToString(),
        Lectures = examinationSessionData[1, 3]?.ToString(),
        Laboratory = examinationSessionData[1, 4]?.ToString(),
        Practical = examinationSessionData[1, 5]?.ToString(),
        IndividualWork = examinationSessionData[1, 6]?.ToString(),
        CourseWork = examinationSessionData[1, 7]?.ToString(),
        ControlWork = examinationSessionData[1, 8]?.ToString(),
        Exam = examinationSessionData[1, 9]?.ToString(),
        Credit = examinationSessionData[1, 10]?.ToString()
      };
    }

    private FullTimeEntryLoadDto GetFullEntryLoadData(object[,] entryLoadData, DisciplineDto discipline)
    {
      return new FullTimeEntryLoadDto
      {
        Faculty = _faculties.SingleOrDefault(f => f.CodeFaculty.Equals(entryLoadData[1, 1]?.ToString().ToLower())),
        Specialty = entryLoadData[1, 2]?.ToString(),
        Specialization = entryLoadData[1, 3]?.ToString(),
        Course = entryLoadData[1, 4]?.ToString(),
        EducationalDegree = entryLoadData[1, 5]?.ToString(),
        AmountOfStudents = entryLoadData[1, 6]?.ToString(),
        AmountOfForeignersStudents = entryLoadData[1, 7]?.ToString(),
        GroupCode = entryLoadData[1, 8]?.ToString(),
        NumberOfGroups = entryLoadData[1, 9]?.ToString(),
        RealNumberOfGroups = entryLoadData[1, 10]?.ToString(),
        NumberOfSubGroups = entryLoadData[1, 11]?.ToString(),
        AmountOfStudentsStreams = entryLoadData[1, 12]?.ToString(),
        ConnectingOfStudentStreams = entryLoadData[1, 13]?.ToString(),
        Notes = entryLoadData[1, 14]?.ToString(),
        Discipline = discipline
      };
    }

    private DisciplineDto GetDisciplineData(object[,] disciplineData, FirstSemesterDto firstSemester,
      SecondSemesterDto secondSemester, object[,] codeDepartmentData)
    {
      return new DisciplineDto
      {
        Name = disciplineData[1, 1]?.ToString(),
        ECTS = disciplineData[1, 2]?.ToString(),
        AmountOfHours = disciplineData[1, 3]?.ToString(),
        Language = disciplineData[1, 4]?.ToString(),
        WeeksInFirstSemester = disciplineData[1, 5]?.ToString(),
        WeeksInSecondSemester = disciplineData[1, 6]?.ToString(),
        FirstSemester = firstSemester.Hours == null ? null : firstSemester,
        SecondSemester = secondSemester.Hours == null ? null : secondSemester,
        Department = _departments.SingleOrDefault(d => d.CodeDepartment.Equals(codeDepartmentData[1, 1]?.ToString().ToLower())),
      };
    }

    private static FirstSemesterDto GetFirstSemesterData(object[,] firstSemesterData)
    {
      return new FirstSemesterDto
      {
        Hours = firstSemesterData[1, 1]?.ToString(),
        HoursAll = firstSemesterData[1, 2]?.ToString(),
        Lectures = firstSemesterData[1, 3]?.ToString(),
        Laboratory = firstSemesterData[1, 4]?.ToString(),
        Practical = firstSemesterData[1, 5]?.ToString(),
        IndividualWork = firstSemesterData[1, 6]?.ToString(),
        CourseWork = firstSemesterData[1, 7]?.ToString(),
        Exam = firstSemesterData[1, 8]?.ToString(),
        Credit = firstSemesterData[1, 9]?.ToString(),
      };
    }

    private static SecondSemesterDto GetSecondSemesterData(object[,] secondSemesterData)
    {
      return new SecondSemesterDto
      {
        Hours = secondSemesterData[1, 1]?.ToString(),
        HoursAll = secondSemesterData[1, 2]?.ToString(),
        Lectures = secondSemesterData[1, 3]?.ToString(),
        Laboratory = secondSemesterData[1, 4]?.ToString(),
        Practical = secondSemesterData[1, 5]?.ToString(),
        IndividualWork = secondSemesterData[1, 6]?.ToString(),
        CourseWork = secondSemesterData[1, 7]?.ToString(),
        Exam = secondSemesterData[1, 8]?.ToString(),
        Credit = secondSemesterData[1, 9]?.ToString(),
      };
    }

    private async Task InsertEntryLoadsPropertyData(int hoursPerRate, string fileName)
    {
      await ServiceFactory.EntryLoadsPropertyService.InsertEntryLoadsProperty(new EntryLoadsPropertyDto
      {
        Name = fileName,
        DateTimeUpload = DateTime.Now,
        HoursPerRate = hoursPerRate,
        IsActive = true
      });
    }

    private async Task InsertData(FirstSemesterDto firstSemester,
      SecondSemesterDto secondSemester, DisciplineDto discipline, FullTimeEntryLoadDto fullTimeEntryLoad)
    {

      if (firstSemester.Hours != null)
      {
        firstSemester.Id = await ServiceFactory.FirstSemester.InsertFirstSemester(firstSemester);
      }

      if (secondSemester.Hours != null)
      {
        secondSemester.Id = await ServiceFactory.SecondSemester.InsertSecondSemester(secondSemester);
      }

      discipline.Id = await ServiceFactory.DisciplineService.InsertDiscipline(discipline);

      await ServiceFactory.FullTimeEntryLoadService.InsertFullTimeEntryLoad(fullTimeEntryLoad);
    }

    private async Task InsertData(ConstituentSessionDto constituentSession, ExaminationSessionDto examinationSession,
      PartTimeDisciplineDto discipline, PartTimeEntryLoadDto entryLoad)
    {
      if (constituentSession.Hours != null)
      {
        constituentSession.Id = await ServiceFactory.ConstituentSessionService.InsertConstituentSession(constituentSession);
      }

      if (examinationSession.Hours != null)
      {
        examinationSession.Id = await ServiceFactory.ExaminationSessionService.InsertExaminationSession(examinationSession);
      }

      discipline.Id = await ServiceFactory.PartTimeDisciplineService.InsertPartTimeDiscipline(discipline);

      await ServiceFactory.PartTimeEntryLoadService.InsertPartTimeEntryLoad(entryLoad);
    }

    private async Task GetFacultiesAndDepartmentsData()
    {
      _faculties = await ServiceFactory.FacultyService.GetFaculties();
      _departments = await ServiceFactory.DepartmentService.GetDepartments();
    }

    #endregion
  }
}
