using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Planner.Entities.DTO.AppEntryLoadDto;
using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using Planner.Entities.DTO.AppUserDto;
using Planner.Entities.DTO.UniversityUnits;
using Planner.PresentationLayer.ViewModels;
using Planner.ServiceInterfaces.Interfaces.ServiceFactory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

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
      var entryLoadsProperties = await ServiceFactory.EntryLoadPropertyService.GetEntryLoadsProperties();
      var entryLoadsPropertiesViewModel = Mapper.Map<IEnumerable<EntryLoadsPropertyViewModel>>(entryLoadsProperties);

      return Ok(entryLoadsPropertiesViewModel);
    }


    [HttpGet("[action]")]
    public async Task<IActionResult> GetUserEntryLoadPropertiesByUserId(int userId)
    {
      var entryLoadsProperties = await ServiceFactory.UserEntryLoadPropertyService.GetUserEntryLoadPropertiesByUserId(userId);
      var entryLoadsPropertiesViewModel = Mapper.Map<IEnumerable<UserEntryLoadsPropertyViewModel>>(entryLoadsProperties);

      return Ok(entryLoadsPropertiesViewModel);
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> MakeAnEntryLoadPlan(int userId)
    {
      var fullTimeEntryLoads = await ServiceFactory.FullTimeEntryLoadService.GetFullTimeEntryLoadsByUserId(userId);
      var partTimeEntryLoads = await ServiceFactory.PartTimeEntryLoadService.GetPartTimeEntryLoadsByUserId(userId);

      var path = Path.Combine(_hostingEnvironment.WebRootPath, "EntryLoadsFiles", "BaseEntryLoadFile", "base.xlsx");
      var excel = new ExcelApi.ExcelApi(path, 1);

      var rowIndex = 6;
      foreach (var fullTimeEntryLoad in fullTimeEntryLoads)
      {
        WriteFullTimeData(excel, rowIndex, GenerateListOfData(fullTimeEntryLoad));

        rowIndex++;
      }
      excel.ChangeSheet(2);

      rowIndex = 6;
      foreach (var partTimeEntryLoad in partTimeEntryLoads)
      {
        WritePartTimeData(excel, rowIndex, GenerateListOfData(partTimeEntryLoad));

        rowIndex++;
      }

      var fileName = $"{DateTime.Now.GetHashCode()}.xlsx";

      await InsertUserEntryLoadsPropertyData(userId, fileName);
      path = Path.Combine(_hostingEnvironment.WebRootPath, "EntryLoadsFiles", "UserEntryLoadFiles", fileName);

      excel.SaveCopyAs(path);

      excel.Close();
      ExcelApi.ExcelApi.KillExcelProcesses();

      return Ok(path);
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> UpdateEntryLoadFile(int id)
    {
      var entryLoadsProperties = await ServiceFactory.EntryLoadPropertyService.GetEntryLoadsProperties();

      var entryLoadsProperty = await ChangeIsActiveEntryLoadsProperties(id, entryLoadsProperties);

      await GetFacultiesAndDepartmentsData();
      await ServiceFactory.EntryLoadPropertyService.RecreateTables();

      var path = Path.Combine(_hostingEnvironment.WebRootPath, "EntryLoadsFiles", entryLoadsProperty.Name);

      var excel = new ExcelApi.ExcelApi(path, 1);

      await ReadFullTimeData(excel);
      excel.ChangeSheet(2);
      await ReadPartTimeData(excel);

      excel.Close();
      ExcelApi.ExcelApi.KillExcelProcesses();

      return Ok(entryLoadsProperty);
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> DeleteEntryLoadFile(int id)
    {
      var entryLoadsProperty = await ServiceFactory.EntryLoadPropertyService.GetEntryLoadsPropertyById(id);

      var path = Path.Combine(_hostingEnvironment.WebRootPath, "EntryLoadsFiles", entryLoadsProperty.Name);

      if (!System.IO.File.Exists(path))
      {
        return NotFound("Файл не знайдено");
      }

      System.IO.File.Delete(path);
      await ServiceFactory.EntryLoadPropertyService.DeleteEntryLoadsProperty(id);

      return Ok("Файл видалено з серверу");

    }

    [HttpPost("[action]")]
    public async Task<IActionResult> DeleteUserEntryLoadFile(int id)
    {
      var userEntryLoadProperty = await ServiceFactory.UserEntryLoadPropertyService.GetUserEntryLoadPropertyById(id);

      var path = Path.Combine(_hostingEnvironment.WebRootPath, "EntryLoadsFiles", "UserEntryLoadFiles", userEntryLoadProperty.Name);

      if (!System.IO.File.Exists(path))
      {
        return NotFound("Файл не знайдено");
      }

      System.IO.File.Delete(path);
      await ServiceFactory.UserEntryLoadPropertyService.DeleteUserEntryLoadProperty(userEntryLoadProperty.Id);

      return Ok("Файл видалено з серверу");

    }


    [HttpGet("[action]")]
    public async Task<IActionResult> DownloadFile(int id)
    {
      var userEntryLoadsProperty = await ServiceFactory.UserEntryLoadPropertyService.GetUserEntryLoadPropertyById(id);

      const string xlsxFileType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
      var path = Path.Combine(_hostingEnvironment.WebRootPath, "EntryLoadsFiles", "UserEntryLoadFiles",
        userEntryLoadsProperty.Name);

      return PhysicalFile(path, xlsxFileType, userEntryLoadsProperty.UserName);
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
          fileName += fileInfo.File.ContentType;

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

    private static IEnumerable<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties, object obj)
    {
      return listOfProperties
        .Select(prop => new { prop, attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false) })
        .Where(t => t.attributes.Length <= 0 || (t.attributes[0] as DescriptionAttribute)?.Description != "Ignore")
        .Select(t => t.prop.GetValue(obj)?.ToString());
    }

    private static void WriteFullTimeData(ExcelApi.ExcelApi excel, int rowIndex,
      IReadOnlyCollection<string> listOfProperties)
    {
      excel.WriteRange($"A{rowIndex}", $"N{rowIndex}", listOfProperties.TakeWhile((x, y) => y <= 13));
      excel.WriteRange($"AQ{rowIndex}", $"AS{rowIndex}", listOfProperties.TakeWhile((x, y) => y >= 14 && y <= 16));
      excel.WriteRange($"CG{rowIndex}", $"CH{rowIndex}", listOfProperties.TakeWhile((x, y) => y >= 17 && y <= 18));
      excel.WriteRange($"O{rowIndex}", $"T{rowIndex}", listOfProperties.TakeWhile((x, y) => y >= 19 && y <= 24));
      excel.WriteRange($"U{rowIndex}", $"AC{rowIndex}", listOfProperties.TakeWhile((x, y) => y >= 25 && y <= 33));
      excel.WriteRange($"AD{rowIndex}", $"AL{rowIndex}", listOfProperties.TakeWhile((x, y) => y >= 34 && y <= 42));
      excel.WriteRange($"AU{rowIndex}", $"BJ{rowIndex}", listOfProperties.TakeWhile((x, y) => y >= 44 && y <= 59));
      excel.WriteRange($"BN{rowIndex}", $"CC{rowIndex}", listOfProperties.TakeWhile((x, y) => y >= 61 && y <= 76));

      excel.WriteCell(rowIndex, 39, listOfProperties.TakeWhile((x, y) => y == 43).Single());
      excel.WriteCell(rowIndex, 64, listOfProperties.TakeWhile((x, y) => y == 60).Single());
      excel.WriteCell(rowIndex, 84, listOfProperties.TakeWhile((x, y) => y == 77).Single());
    }

    private static void WritePartTimeData(ExcelApi.ExcelApi excel, int rowIndex,
      IReadOnlyCollection<string> listOfProperties)
    {
      excel.WriteRange($"A{rowIndex}", $"L{rowIndex}", listOfProperties.Where((x, y) => y <= 11));
      excel.WriteRange($"M{rowIndex}", $"R{rowIndex}", listOfProperties.Where((x, y) => y >= 14 && y <= 19));
      excel.WriteRange($"S{rowIndex}", $"AB{rowIndex}", listOfProperties.Where((x, y) => y >= 21 && y <= 29));
      excel.WriteRange($"AC{rowIndex}", $"AM{rowIndex}", listOfProperties.Where((x, y) => y >= 30 && y <= 40));
      excel.WriteRange($"AP{rowIndex}", $"BE{rowIndex}", listOfProperties.Where((x, y) => y >= 41 && y <= 56));
      excel.WriteRange($"BI{rowIndex}", $"BX{rowIndex}", listOfProperties.Where((x, y) => y >= 58 && y <= 73));
      excel.WriteRange($"CB{rowIndex}", $"CC{rowIndex}", listOfProperties.Where((x, y) => y >= 12 && y <= 13));

      excel.WriteCell(rowIndex, 59, listOfProperties.Where((x, y) => y == 57).Single());
      excel.WriteCell(rowIndex, 74, listOfProperties.Where((x, y) => y == 74).Single());
    }

    private static List<string> GenerateListOfData(FullTimeEntryLoadDto fullTimeEntryLoad)
    {
      var listOfProperties = new List<string> { fullTimeEntryLoad.Faculty.CodeFaculty };

      listOfProperties.AddRange(GenerateListOfProperties(typeof(FullTimeEntryLoadDto).GetProperties(),
        fullTimeEntryLoad));

      listOfProperties.AddRange(GenerateListOfProperties(typeof(FullTimeDisciplineDto).GetProperties(),
        fullTimeEntryLoad.FullTimeDiscipline));

      listOfProperties.AddRange(fullTimeEntryLoad.FullTimeDiscipline.FirstSemester != null
        ? GenerateListOfProperties(typeof(FirstSemesterDto).GetProperties(),
          fullTimeEntryLoad.FullTimeDiscipline.FirstSemester)
        : new string[9]);

      listOfProperties.AddRange(fullTimeEntryLoad.FullTimeDiscipline.SecondSemester != null
        ? GenerateListOfProperties(typeof(SecondSemesterDto).GetProperties(),
          fullTimeEntryLoad.FullTimeDiscipline.SecondSemester)
        : new string[9]);

      listOfProperties.Add(fullTimeEntryLoad.FullTimeDiscipline?.Department.CodeDepartment);

      if (!fullTimeEntryLoad.HoursCalculationOfFirstSemester.All.Equals("0"))
      {
        listOfProperties.AddRange(GenerateListOfProperties(typeof(HoursCalculationOfFirstSemesterDto).GetProperties(),
          fullTimeEntryLoad.HoursCalculationOfFirstSemester));
      }
      else
      {
        listOfProperties.AddRange(new string[17]);
      }

      if (!fullTimeEntryLoad.HoursCalculationOfSecondSemester.All.Equals("0"))
      {
        listOfProperties.AddRange(GenerateListOfProperties(typeof(HoursCalculationOfSecondSemesterDto).GetProperties(),
          fullTimeEntryLoad.HoursCalculationOfSecondSemester));
      }
      else
      {
        listOfProperties.AddRange(new string[17]);
      }

      return listOfProperties;
    }

    private static List<string> GenerateListOfData(PartTimeEntryLoadDto partTimeEntryLoad)
    {
      var listOfProperties = new List<string>();

      listOfProperties.AddRange(GenerateListOfProperties(typeof(PartTimeEntryLoadDto).GetProperties(),
        partTimeEntryLoad));

      listOfProperties.AddRange(GenerateListOfProperties(typeof(PartTimeDisciplineDto).GetProperties(),
        partTimeEntryLoad.PartTimeDiscipline));

      listOfProperties.AddRange(partTimeEntryLoad.PartTimeDiscipline.ConstituentSession != null
        ? GenerateListOfProperties(typeof(ConstituentSessionDto).GetProperties(),
          partTimeEntryLoad.PartTimeDiscipline.ConstituentSession)
        : new string[10]);

      listOfProperties.AddRange(partTimeEntryLoad.PartTimeDiscipline.ExaminationSession != null
        ? GenerateListOfProperties(typeof(ExaminationSessionDto).GetProperties(),
          partTimeEntryLoad.PartTimeDiscipline.ExaminationSession)
        : new string[10]);

      listOfProperties.Add(partTimeEntryLoad.PartTimeDiscipline?.Department.CodeDepartment);

      if (!partTimeEntryLoad.HoursCalculationOfFirstSemester.All.Equals("0"))
      {
        listOfProperties.AddRange(GenerateListOfProperties(typeof(HoursCalculationOfFirstSemesterDto).GetProperties(),
          partTimeEntryLoad.HoursCalculationOfFirstSemester));
      }
      else
      {
        listOfProperties.AddRange(new string[17]);
      }

      if (!partTimeEntryLoad.HoursCalculationOfSecondSemester.All.Equals("0"))
      {
        listOfProperties.AddRange(GenerateListOfProperties(typeof(HoursCalculationOfSecondSemesterDto).GetProperties(),
          partTimeEntryLoad.HoursCalculationOfSecondSemester));
      }
      else
      {
        listOfProperties.AddRange(new string[17]);
      }

      return listOfProperties;
    }

    private async Task<EntryLoadsPropertyDto> ChangeIsActiveEntryLoadsProperties(int id,
      IEnumerable<EntryLoadsPropertyDto> entryLoadsProperties)
    {
      var entryLoadsProperty = entryLoadsProperties.Single(x => x.Id == id);
      var entryLoadsPropertyIsActive = entryLoadsProperties.Single(x => x.IsActive);

      entryLoadsPropertyIsActive.IsActive = false;
      await ServiceFactory.EntryLoadPropertyService.UpdateEntryLoadsProperty(entryLoadsPropertyIsActive);

      entryLoadsProperty.IsActive = true;
      await ServiceFactory.EntryLoadPropertyService.UpdateEntryLoadsProperty(entryLoadsProperty);

      return entryLoadsProperty;
    }

    private async Task ReadFullTimeData(ExcelApi.ExcelApi excel)
    {
      for (var i = 6; i <= excel.Count; i++)
      {
        var entryLoadData = excel.ReadRange($"A{i}", $"N{i}");
        var entryLoadNormsData = excel.ReadRange($"AQ{i}", $"AS{i}");
        var entryLoadHoursData = excel.ReadRange($"CG{i}", $"CH{i}");

        var disciplineData = excel.ReadRange($"O{i}", $"T{i}");
        var firstSemesterData = excel.ReadRange($"U{i}", $"AC{i}");
        var secondSemesterData = excel.ReadRange($"AD{i}", $"AL{i}");

        var codeDepartmentData = excel.ReadRange($"AM{i}", $"AN{i}");

        var hoursCalculationOfFirstSemesterData = excel.ReadRange($"AU{i}", $"BL{i}");
        var hoursCalculationOfSecondSemesterData = excel.ReadRange($"BN{i}", $"CE{i}");

        var firstSemester = GetFirstSemesterData(firstSemesterData);
        var secondSemester = GetSecondSemesterData(secondSemesterData);

        var discipline = GetFullTimeDisciplineData(disciplineData, firstSemester, secondSemester, codeDepartmentData);

        var hoursCalculationOfFirstSemester = GetHoursCalculationOfFirstSemesterData(hoursCalculationOfFirstSemesterData);
        var hoursCalculationOfSecondSemester = GetHoursCalculationOfSecondSemesterData(hoursCalculationOfSecondSemesterData);

        var entryLoad = GetFullEntryLoadData(entryLoadData, entryLoadHoursData, entryLoadNormsData, discipline,
          hoursCalculationOfFirstSemester, hoursCalculationOfSecondSemester);

        if (entryLoad.Specialization == null)
        {
          break;
        }

        await InsertData(firstSemester, secondSemester, discipline,
          hoursCalculationOfFirstSemester, hoursCalculationOfSecondSemester, entryLoad);
      }
    }

    private async Task ReadPartTimeData(ExcelApi.ExcelApi excel)
    {
      for (var i = 6; i < excel.Count; i++)
      {
        var entryLoadData = excel.ReadRange($"A{i}", $"L{i}");
        var entryLoadHoursData = excel.ReadRange($"CB{i}", $"CC{i}");

        var disciplineData = excel.ReadRange($"M{i}", $"R{i}");
        var constituentSessionData = excel.ReadRange($"S{i}", $"AB{i}");
        var examinationSessionData = excel.ReadRange($"AC{i}", $"AL{i}");

        var codeDepartmentData = excel.ReadRange($"AM{i}", $"AN{i}");

        var hoursCalculationOfFirstSemesterData = excel.ReadRange($"AP{i}", $"BG{i}");
        var hoursCalculationOfSecondSemesterData = excel.ReadRange($"BI{i}", $"BZ{i}");

        var constituentSession = GetConstituentSessionData(constituentSessionData);
        var examinationSession = GetExaminationSessionData(examinationSessionData);

        var discipline = GetPartTimeDisciplineData(disciplineData, constituentSession, examinationSession, codeDepartmentData);

        var hoursCalculationOfFirstSemester = GetHoursCalculationOfFirstSemesterData(hoursCalculationOfFirstSemesterData);
        var hoursCalculationOfSecondSemester = GetHoursCalculationOfSecondSemesterData(hoursCalculationOfSecondSemesterData);

        var entryLoad = GetPartTimeEntryLoadData(entryLoadData, entryLoadHoursData, discipline,
          hoursCalculationOfFirstSemester, hoursCalculationOfSecondSemester);

        if (entryLoad.Unit == null)
        {
          break;
        }

        await InsertData(constituentSession, examinationSession, discipline,
          hoursCalculationOfFirstSemester, hoursCalculationOfSecondSemester, entryLoad);
      }
    }

    private static HoursCalculationOfSecondSemesterDto GetHoursCalculationOfSecondSemesterData(object[,] hoursCalculationOfSecondSemesterData)
    {
      return new HoursCalculationOfSecondSemesterDto
      {
        Lectures = hoursCalculationOfSecondSemesterData[1, 1]?.ToString(),
        Laboratories = hoursCalculationOfSecondSemesterData[1, 2]?.ToString(),
        Practicals = hoursCalculationOfSecondSemesterData[1, 3]?.ToString(),
        ConsultationsDuringTheSemester = hoursCalculationOfSecondSemesterData[1, 4]?.ToString(),
        ConsultationsBeforeTheExam = hoursCalculationOfSecondSemesterData[1, 5]?.ToString(),
        CheckingOfControlWorks = hoursCalculationOfSecondSemesterData[1, 6]?.ToString(),
        KRKP = hoursCalculationOfSecondSemesterData[1, 7]?.ToString(),
        ConductionOfCredit = hoursCalculationOfSecondSemesterData[1, 8]?.ToString(),
        ConductionOfExam = hoursCalculationOfSecondSemesterData[1, 9]?.ToString(),
        PracticalTrainingGuide = hoursCalculationOfSecondSemesterData[1, 10]?.ToString(),
        ParticipationInDec = hoursCalculationOfSecondSemesterData[1, 11]?.ToString(),
        ConductionOfTheStateExam = hoursCalculationOfSecondSemesterData[1, 12]?.ToString(),
        GuidanceDiplomaWorks = hoursCalculationOfSecondSemesterData[1, 13]?.ToString(),
        Another = hoursCalculationOfSecondSemesterData[1, 14]?.ToString(),
        All = hoursCalculationOfSecondSemesterData[1, 15]?.ToString(),
        Active = hoursCalculationOfSecondSemesterData[1, 16]?.ToString(),
        Bonus = hoursCalculationOfSecondSemesterData[1, 18]?.ToString(),
      };
    }

    private static HoursCalculationOfFirstSemesterDto GetHoursCalculationOfFirstSemesterData(object[,] hoursCalculationOfFirstSemesterData)
    {
      return new HoursCalculationOfFirstSemesterDto
      {
        Lectures = hoursCalculationOfFirstSemesterData[1, 1]?.ToString(),
        Laboratories = hoursCalculationOfFirstSemesterData[1, 2]?.ToString(),
        Practicals = hoursCalculationOfFirstSemesterData[1, 3]?.ToString(),
        ConsultationsDuringTheSemester = hoursCalculationOfFirstSemesterData[1, 4]?.ToString(),
        ConsultationsBeforeTheExam = hoursCalculationOfFirstSemesterData[1, 5]?.ToString(),
        CheckingOfControlWorks = hoursCalculationOfFirstSemesterData[1, 6]?.ToString(),
        KRKP = hoursCalculationOfFirstSemesterData[1, 7]?.ToString(),
        ConductionOfCredit = hoursCalculationOfFirstSemesterData[1, 8]?.ToString(),
        ConductionOfExam = hoursCalculationOfFirstSemesterData[1, 9]?.ToString(),
        PracticalTrainingGuide = hoursCalculationOfFirstSemesterData[1, 10]?.ToString(),
        ParticipationInDec = hoursCalculationOfFirstSemesterData[1, 11]?.ToString(),
        ConductionOfTheStateExam = hoursCalculationOfFirstSemesterData[1, 12]?.ToString(),
        GuidanceDiplomaWorks = hoursCalculationOfFirstSemesterData[1, 13]?.ToString(),
        Another = hoursCalculationOfFirstSemesterData[1, 14]?.ToString(),
        All = hoursCalculationOfFirstSemesterData[1, 15]?.ToString(),
        Active = hoursCalculationOfFirstSemesterData[1, 16]?.ToString(),
        Bonus = hoursCalculationOfFirstSemesterData[1, 18]?.ToString(),
      };
    }

    private static PartTimeEntryLoadDto GetPartTimeEntryLoadData(object[,] entryLoadData, object[,] entryLoadHoursData,
      PartTimeDisciplineDto discipline,
      HoursCalculationOfFirstSemesterDto hoursCalculationOfFirstSemester,
      HoursCalculationOfSecondSemesterDto hoursCalculationOfSecondSemester)
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
        PartTimeDiscipline = discipline,
        HoursCalculationOfFirstSemester = hoursCalculationOfFirstSemester.All == null ? null : hoursCalculationOfFirstSemester,
        HoursCalculationOfSecondSemester = hoursCalculationOfSecondSemester.All == null ? null : hoursCalculationOfSecondSemester,
        All = entryLoadHoursData[1, 1]?.ToString(),
        Active = entryLoadHoursData[1, 2]?.ToString()
      };
    }

    private PartTimeDisciplineDto GetPartTimeDisciplineData(object[,] disciplineData,
      ConstituentSessionDto constituentSession,
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

    private FullTimeEntryLoadDto GetFullEntryLoadData(object[,] entryLoadData, object[,] entryLoadHoursData, object[,] entryLoadNormsData,
      FullTimeDisciplineDto fullTimeDiscipline,
      HoursCalculationOfFirstSemesterDto hoursCalculationOfFirstSemester,
      HoursCalculationOfSecondSemesterDto hoursCalculationOfSecondSemester)
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
        FullTimeDiscipline = fullTimeDiscipline,
        HoursCalculationOfFirstSemester = hoursCalculationOfFirstSemester.All == null ? null : hoursCalculationOfFirstSemester,
        HoursCalculationOfSecondSemester = hoursCalculationOfSecondSemester.All == null ? null : hoursCalculationOfSecondSemester,
        KRKPDR = entryLoadNormsData[1, 1]?.ToString(),
        Practical = entryLoadNormsData[1, 2]?.ToString(),
        AmountOfPeopleDec = entryLoadNormsData[1, 3]?.ToString(),
        All = entryLoadHoursData[1, 1]?.ToString(),
        Active = entryLoadHoursData[1, 2]?.ToString()
      };
    }

    private FullTimeDisciplineDto GetFullTimeDisciplineData(object[,] disciplineData, FirstSemesterDto firstSemester,
      SecondSemesterDto secondSemester, object[,] codeDepartmentData)
    {
      return new FullTimeDisciplineDto
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
      await ServiceFactory.EntryLoadPropertyService.InsertEntryLoadsProperty(new EntryLoadsPropertyDto
      {
        Name = fileName,
        DateTimeUpload = DateTime.Now,
        HoursPerRate = hoursPerRate,
        IsActive = false
      });
    }

    private async Task InsertUserEntryLoadsPropertyData(int userId, string fileName)
    {
      await ServiceFactory.UserEntryLoadPropertyService.InsertUserEntryLoadProperty(new UserEntryLoadPropertyDto
      {
        Name = fileName,
        UserId = userId,
        UserName = await ServiceFactory.UserService.GetUserNameById(userId),
        DateTimeUpload = DateTime.Now
      });
    }

    private async Task InsertData(FirstSemesterDto firstSemester,
      SecondSemesterDto secondSemester, FullTimeDisciplineDto fullTimeDiscipline,
      HoursCalculationOfFirstSemesterDto hoursCalculationOfFirstSemester,
      HoursCalculationOfSecondSemesterDto hoursCalculationOfSecondSemester, FullTimeEntryLoadDto fullTimeEntryLoad)
    {

      if (firstSemester.Hours != null)
      {
        firstSemester.Id = await ServiceFactory.FirstSemester.InsertFirstSemester(firstSemester);
      }

      if (secondSemester.Hours != null)
      {
        secondSemester.Id = await ServiceFactory.SecondSemester.InsertSecondSemester(secondSemester);
      }

      fullTimeDiscipline.Id = await ServiceFactory.FullTimeDisciplineService.InsertFullTimeDiscipline(fullTimeDiscipline);

      if (hoursCalculationOfFirstSemester.All != null)
      {
        hoursCalculationOfFirstSemester.Id =
          await ServiceFactory.HoursCalculationOfFirstSemesterService.InsertHoursCalculationOfFirstSemester(
            hoursCalculationOfFirstSemester);
      }

      if (hoursCalculationOfSecondSemester.All != null)
      {
        hoursCalculationOfSecondSemester.Id =
          await ServiceFactory.HoursCalculationOfSecondSemesterService.InsertHoursCalculationOfSecondSemester(
            hoursCalculationOfSecondSemester);
      }

      await ServiceFactory.FullTimeEntryLoadService.InsertFullTimeEntryLoad(fullTimeEntryLoad);
    }

    private async Task InsertData(ConstituentSessionDto constituentSession, ExaminationSessionDto examinationSession,
      PartTimeDisciplineDto discipline,
      HoursCalculationOfFirstSemesterDto hoursCalculationOfFirstSemester,
      HoursCalculationOfSecondSemesterDto hoursCalculationOfSecondSemester,
      PartTimeEntryLoadDto entryLoad)
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

      if (hoursCalculationOfFirstSemester.All != null)
      {
        hoursCalculationOfFirstSemester.Id =
          await ServiceFactory.HoursCalculationOfFirstSemesterService.InsertHoursCalculationOfFirstSemester(
            hoursCalculationOfFirstSemester);
      }

      if (hoursCalculationOfSecondSemester.All != null)
      {
        hoursCalculationOfSecondSemester.Id =
          await ServiceFactory.HoursCalculationOfSecondSemesterService.InsertHoursCalculationOfSecondSemester(
            hoursCalculationOfSecondSemester);
      }

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
