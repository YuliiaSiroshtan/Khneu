using AutoMapper;
using Planner.BusinessLogic.Service.Base;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.Entities.DTO.AppEntryLoadDto;
using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using Planner.Entities.DTO.UniversityUnits;
using Planner.ExcelApi;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppExcel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppExcel
{
    public class ExcelService : BaseService, IExcelService
    {
        private readonly Func<Task> _initDepartmentsAndFaculties;
        private IEnumerable<DepartmentDto> _departments;
        private IExcelApi _excel;
        private IEnumerable<FacultyDto> _faculties;

        public ExcelService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) =>
            this._initDepartmentsAndFaculties = async () =>
            {
                this._departments =
                    this.Mapper.Map<IEnumerable<DepartmentDto>>(await this.Uow.DepartmentRepository.GetDepartments());
                this._faculties =
                    this.Mapper.Map<IEnumerable<FacultyDto>>(await this.Uow.FacultyRepository.GetFaculties());
            };

        public void Write(IEnumerable<FullTimeEntryLoadDto> fullTimeEntryLoads,
            IEnumerable<PartTimeEntryLoadDto> partTimeEntryLoads, string path)
        {
            using var excel = this._excel = new ExcelApi.ExcelApi(new FileInfo(path), 1);

            var rowIndex = 6;
            foreach (var fullTimeEntryLoad in fullTimeEntryLoads)
            {
                this.WriteFullTimeData(rowIndex, GenerateListOfData(fullTimeEntryLoad));

                rowIndex++;
            }

            excel.ChangeSheet(2);

            rowIndex = 6;
            foreach (var partTimeEntryLoad in partTimeEntryLoads)
            {
                this.WritePartTimeData(rowIndex, GenerateListOfData(partTimeEntryLoad));

                rowIndex++;
            }
        }

        public async Task Read(string path)
        {
            await this._initDepartmentsAndFaculties();

            using var excel = this._excel = new ExcelApi.ExcelApi(new FileInfo(path), 1);

            for (var i = 6; i <= this._excel.Count; i++)
            {
                var (firstSemester,
                    secondSemester,
                    discipline,
                    hoursCalculationOfFirstSemester,
                    hoursCalculationOfSecondSemester,
                    entryLoad) = this.ReadFullTimeData(i);

                if (entryLoad.Faculty == null) break;

                await this.InsertData(
                    firstSemester,
                    secondSemester,
                    discipline,
                    hoursCalculationOfFirstSemester,
                    hoursCalculationOfSecondSemester,
                    entryLoad);
            }

            excel.ChangeSheet(2);

            for (var i = 6; i < this._excel.Count; i++)
            {
                var (constituentSession, examinationSession, discipline, hoursCalculationOfFirstSemester,
                    hoursCalculationOfSecondSemester, entryLoad) = this.ReadPartTimeData(i);

                if (entryLoad.Unit == null) break;

                await this.InsertData(
                    constituentSession,
                    examinationSession,
                    discipline,
                    hoursCalculationOfFirstSemester,
                    hoursCalculationOfSecondSemester,
                    entryLoad);
            }
        }

        public void Save(string path) => this._excel.SaveAs(path);

        #region private methods

        #region ReadData

        private (FirstSemesterDto firstSemester,
            SecondSemesterDto secondSemester,
            FullTimeDisciplineDto discipline,
            HoursCalculationOfFirstSemesterDto hoursCalculationOfFirstSemester,
            HoursCalculationOfSecondSemesterDto hoursCalculationOfSecondSemester,
            FullTimeEntryLoadDto entryLoad)
            ReadFullTimeData(int rowIndex)
        {
            var entryLoadData = this._excel.ReadRange($"A{rowIndex}:N{rowIndex}");
            var entryLoadNormsData = this._excel.ReadRange($"AQ{rowIndex}:AS{rowIndex}");
            var entryLoadHoursData = this._excel.ReadRange($"CG{rowIndex}:CH{rowIndex}");

            var disciplineData = this._excel.ReadRange($"O{rowIndex}:T{rowIndex}");
            var firstSemesterData = this._excel.ReadRange($"U{rowIndex}:AC{rowIndex}");
            var secondSemesterData = this._excel.ReadRange($"AD{rowIndex}:AL{rowIndex}");

            var codeDepartmentData = this._excel.ReadRange($"AM{rowIndex}:AN{rowIndex}");

            var hoursCalculationOfFirstSemesterData = this._excel.ReadRange($"AU{rowIndex}:BL{rowIndex}");
            var hoursCalculationOfSecondSemesterData = this._excel.ReadRange($"BN{rowIndex}:CE{rowIndex}");

            var firstSemester = GetFirstSemesterData(firstSemesterData);
            var secondSemester = GetSecondSemesterData(secondSemesterData);

            var discipline = this.GetFullTimeDisciplineData(disciplineData, firstSemester, secondSemester,
                codeDepartmentData);

            var hoursCalculationOfFirstSemester =
                GetHoursCalculationOfFirstSemesterData(hoursCalculationOfFirstSemesterData);
            var hoursCalculationOfSecondSemester =
                GetHoursCalculationOfSecondSemesterData(hoursCalculationOfSecondSemesterData);

            var entryLoad = this.GetFullEntryLoadData(entryLoadData, entryLoadHoursData, entryLoadNormsData,
                discipline,
                hoursCalculationOfFirstSemester, hoursCalculationOfSecondSemester);

            return (firstSemester, secondSemester, discipline, hoursCalculationOfFirstSemester,
                hoursCalculationOfSecondSemester, entryLoad);
        }

        private (ConstituentSessionDto constituentSession,
            ExaminationSessionDto examinationSession,
            PartTimeDisciplineDto discipline,
            HoursCalculationOfFirstSemesterDto hoursCalculationOfFirstSemester,
            HoursCalculationOfSecondSemesterDto hoursCalculationOfSecondSemester,
            PartTimeEntryLoadDto entryLoad)
            ReadPartTimeData(int rowIndex)
        {
            var entryLoadData = this._excel.ReadRange($"A{rowIndex}:L{rowIndex}");
            var entryLoadHoursData = this._excel.ReadRange($"CB{rowIndex}:CC{rowIndex}");

            var disciplineData = this._excel.ReadRange($"M{rowIndex}:R{rowIndex}");
            var constituentSessionData = this._excel.ReadRange($"S{rowIndex}:AB{rowIndex}");
            var examinationSessionData = this._excel.ReadRange($"AC{rowIndex}:AL{rowIndex}");

            var codeDepartmentData = this._excel.ReadRange($"AM{rowIndex}:AN{rowIndex}");

            var hoursCalculationOfFirstSemesterData = this._excel.ReadRange($"AP{rowIndex}:BG{rowIndex}");
            var hoursCalculationOfSecondSemesterData = this._excel.ReadRange($"BI{rowIndex}:BZ{rowIndex}");

            var constituentSession = GetConstituentSessionData(constituentSessionData);
            var examinationSession = GetExaminationSessionData(examinationSessionData);

            var discipline = this.GetPartTimeDisciplineData(disciplineData, constituentSession, examinationSession,
                codeDepartmentData);

            var hoursCalculationOfFirstSemester =
                GetHoursCalculationOfFirstSemesterData(hoursCalculationOfFirstSemesterData);
            var hoursCalculationOfSecondSemester =
                GetHoursCalculationOfSecondSemesterData(hoursCalculationOfSecondSemesterData);

            var entryLoad = GetPartTimeEntryLoadData(entryLoadData, entryLoadHoursData, discipline,
                hoursCalculationOfFirstSemester, hoursCalculationOfSecondSemester);

            return (constituentSession, examinationSession, discipline, hoursCalculationOfFirstSemester,
                hoursCalculationOfSecondSemester, entryLoad);
        }

        #endregion

        #region WriteData

        private void WriteFullTimeData(int rowIndex, IReadOnlyCollection<string> data)
        {
            this._excel.WriteRange($"A{rowIndex}:N{rowIndex}", data.Where((x, y) => y <= 13));
            this._excel.WriteRange($"AQ{rowIndex}:AS{rowIndex}", data.Where((x, y) => y >= 14 && y <= 16));
            this._excel.WriteRange($"CG{rowIndex}:CH{rowIndex}", data.Where((x, y) => y >= 17 && y <= 18));
            this._excel.WriteRange($"O{rowIndex}:T{rowIndex}", data.Where((x, y) => y >= 19 && y <= 24));
            this._excel.WriteRange($"U{rowIndex}:AC{rowIndex}", data.Where((x, y) => y >= 25 && y <= 33));
            this._excel.WriteRange($"AD{rowIndex}:AL{rowIndex}", data.Where((x, y) => y >= 34 && y <= 42));
            this._excel.WriteRange($"AU{rowIndex}:BJ{rowIndex}", data.Where((x, y) => y >= 44 && y <= 59));
            this._excel.WriteRange($"BN{rowIndex}:CC{rowIndex}", data.Where((x, y) => y >= 61 && y <= 76));

            this._excel.WriteCell($"AM{rowIndex}", data.Where((x, y) => y == 43).SingleOrDefault());
            this._excel.WriteCell($"BL{rowIndex}", data.Where((x, y) => y == 60).SingleOrDefault());
            this._excel.WriteCell($"CE{rowIndex}", data.Where((x, y) => y == 77).SingleOrDefault());
        }

        private void WritePartTimeData(int rowIndex, IReadOnlyCollection<string> data)
        {
            this._excel.WriteRange($"A{rowIndex}:L{rowIndex}", data.Where((x, y) => y <= 11));
            this._excel.WriteRange($"M{rowIndex}:R{rowIndex}", data.Where((x, y) => y >= 14 && y <= 19));
            this._excel.WriteRange($"S{rowIndex}:AB{rowIndex}", data.Where((x, y) => y >= 21 && y <= 29));
            this._excel.WriteRange($"AC{rowIndex}:AM{rowIndex}", data.Where((x, y) => y >= 30 && y <= 40));
            this._excel.WriteRange($"AP{rowIndex}:BE{rowIndex}", data.Where((x, y) => y >= 41 && y <= 56));
            this._excel.WriteRange($"BI{rowIndex}:BX{rowIndex}", data.Where((x, y) => y >= 58 && y <= 73));
            this._excel.WriteRange($"CB{rowIndex}:CC{rowIndex}", data.Where((x, y) => y >= 12 && y <= 13));

            this._excel.WriteCell($"BG{rowIndex}", data.Where((x, y) => y == 57).SingleOrDefault());
            this._excel.WriteCell($"BZ{rowIndex}", data.Where((x, y) => y == 74).SingleOrDefault());
        }

        #endregion

        #region GenerateList

        private static IEnumerable<string> GenerateListOfValueProperties(IEnumerable<PropertyInfo> listOfProperties,
            object obj) =>
            listOfProperties.Select(t => t.GetValue(obj)?.ToString());

        private static List<string> GenerateListOfData(FullTimeEntryLoadDto fullTimeEntryLoad)
        {
            var listOfProperties = new List<string> {fullTimeEntryLoad.Faculty.CodeFaculty};

            listOfProperties.AddRange(GenerateListOfValueProperties(typeof(FullTimeEntryLoadDto).GetProperties(),
                fullTimeEntryLoad));

            listOfProperties.AddRange(GenerateListOfValueProperties(typeof(FullTimeDisciplineDto).GetProperties(),
                fullTimeEntryLoad.FullTimeDiscipline));

            listOfProperties.AddRange(fullTimeEntryLoad.FullTimeDiscipline.FirstSemester != null
                ? GenerateListOfValueProperties(typeof(FirstSemesterDto).GetProperties(),
                    fullTimeEntryLoad.FullTimeDiscipline.FirstSemester)
                : new string[9]);

            listOfProperties.AddRange(fullTimeEntryLoad.FullTimeDiscipline.SecondSemester != null
                ? GenerateListOfValueProperties(typeof(SecondSemesterDto).GetProperties(),
                    fullTimeEntryLoad.FullTimeDiscipline.SecondSemester)
                : new string[9]);

            listOfProperties.Add(fullTimeEntryLoad.FullTimeDiscipline?.Department.CodeDepartment);

            if (!fullTimeEntryLoad.HoursCalculationOfFirstSemester.All.Equals("0"))
                listOfProperties.AddRange(GenerateListOfValueProperties(
                    typeof(HoursCalculationOfFirstSemesterDto).GetProperties(),
                    fullTimeEntryLoad.HoursCalculationOfFirstSemester));
            else
                listOfProperties.AddRange(new string[17]);

            if (!fullTimeEntryLoad.HoursCalculationOfSecondSemester.All.Equals("0"))
                listOfProperties.AddRange(GenerateListOfValueProperties(
                    typeof(HoursCalculationOfSecondSemesterDto).GetProperties(),
                    fullTimeEntryLoad.HoursCalculationOfSecondSemester));
            else
                listOfProperties.AddRange(new string[17]);

            return listOfProperties;
        }

        private static List<string> GenerateListOfData(PartTimeEntryLoadDto partTimeEntryLoad)
        {
            var listOfProperties = new List<string>();

            listOfProperties.AddRange(GenerateListOfValueProperties(typeof(PartTimeEntryLoadDto).GetProperties(),
                partTimeEntryLoad));

            listOfProperties.AddRange(GenerateListOfValueProperties(typeof(PartTimeDisciplineDto).GetProperties(),
                partTimeEntryLoad.PartTimeDiscipline));

            listOfProperties.AddRange(partTimeEntryLoad.PartTimeDiscipline.ConstituentSession != null
                ? GenerateListOfValueProperties(typeof(ConstituentSessionDto).GetProperties(),
                    partTimeEntryLoad.PartTimeDiscipline.ConstituentSession)
                : new string[10]);

            listOfProperties.AddRange(partTimeEntryLoad.PartTimeDiscipline.ExaminationSession != null
                ? GenerateListOfValueProperties(typeof(ExaminationSessionDto).GetProperties(),
                    partTimeEntryLoad.PartTimeDiscipline.ExaminationSession)
                : new string[10]);

            listOfProperties.Add(partTimeEntryLoad.PartTimeDiscipline?.Department.CodeDepartment);

            if (!partTimeEntryLoad.HoursCalculationOfFirstSemester.All.Equals("0"))
                listOfProperties.AddRange(GenerateListOfValueProperties(
                    typeof(HoursCalculationOfFirstSemesterDto).GetProperties(),
                    partTimeEntryLoad.HoursCalculationOfFirstSemester));
            else
                listOfProperties.AddRange(new string[17]);

            if (!partTimeEntryLoad.HoursCalculationOfSecondSemester.All.Equals("0"))
                listOfProperties.AddRange(GenerateListOfValueProperties(
                    typeof(HoursCalculationOfSecondSemesterDto).GetProperties(),
                    partTimeEntryLoad.HoursCalculationOfSecondSemester));
            else
                listOfProperties.AddRange(new string[17]);

            return listOfProperties;
        }

        #endregion

        #region GetObjects

        #region HoursCalculation

        private static HoursCalculationOfFirstSemesterDto GetHoursCalculationOfFirstSemesterData(
            object[,] hoursCalculationOfFirstSemesterData) =>
            new HoursCalculationOfFirstSemesterDto
            {
                Lectures = hoursCalculationOfFirstSemesterData[0, 0]?.ToString(),
                Laboratories = hoursCalculationOfFirstSemesterData[0, 1]?.ToString(),
                Practicals = hoursCalculationOfFirstSemesterData[0, 2]?.ToString(),
                ConsultationsDuringTheSemester = hoursCalculationOfFirstSemesterData[0, 3]?.ToString(),
                ConsultationsBeforeTheExam = hoursCalculationOfFirstSemesterData[0, 4]?.ToString(),
                CheckingOfControlWorks = hoursCalculationOfFirstSemesterData[0, 5]?.ToString(),
                KRKP = hoursCalculationOfFirstSemesterData[0, 6]?.ToString(),
                ConductionOfCredit = hoursCalculationOfFirstSemesterData[0, 7]?.ToString(),
                ConductionOfExam = hoursCalculationOfFirstSemesterData[0, 8]?.ToString(),
                PracticalTrainingGuide = hoursCalculationOfFirstSemesterData[0, 9]?.ToString(),
                ParticipationInDec = hoursCalculationOfFirstSemesterData[0, 10]?.ToString(),
                ConductionOfTheStateExam = hoursCalculationOfFirstSemesterData[0, 11]?.ToString(),
                GuidanceDiplomaWorks = hoursCalculationOfFirstSemesterData[0, 12]?.ToString(),
                Another = hoursCalculationOfFirstSemesterData[0, 13]?.ToString(),
                All = hoursCalculationOfFirstSemesterData[0, 14]?.ToString(),
                Active = hoursCalculationOfFirstSemesterData[0, 15]?.ToString(),
                Bonus = hoursCalculationOfFirstSemesterData[0, 17]?.ToString()
            };

        private static HoursCalculationOfSecondSemesterDto GetHoursCalculationOfSecondSemesterData(
            object[,] hoursCalculationOfSecondSemesterData) =>
            new HoursCalculationOfSecondSemesterDto
            {
                Lectures = hoursCalculationOfSecondSemesterData[0, 0]?.ToString(),
                Laboratories = hoursCalculationOfSecondSemesterData[0, 1]?.ToString(),
                Practicals = hoursCalculationOfSecondSemesterData[0, 2]?.ToString(),
                ConsultationsDuringTheSemester = hoursCalculationOfSecondSemesterData[0, 3]?.ToString(),
                ConsultationsBeforeTheExam = hoursCalculationOfSecondSemesterData[0, 4]?.ToString(),
                CheckingOfControlWorks = hoursCalculationOfSecondSemesterData[0, 5]?.ToString(),
                KRKP = hoursCalculationOfSecondSemesterData[0, 6]?.ToString(),
                ConductionOfCredit = hoursCalculationOfSecondSemesterData[0, 7]?.ToString(),
                ConductionOfExam = hoursCalculationOfSecondSemesterData[0, 8]?.ToString(),
                PracticalTrainingGuide = hoursCalculationOfSecondSemesterData[0, 9]?.ToString(),
                ParticipationInDec = hoursCalculationOfSecondSemesterData[0, 10]?.ToString(),
                ConductionOfTheStateExam = hoursCalculationOfSecondSemesterData[0, 11]?.ToString(),
                GuidanceDiplomaWorks = hoursCalculationOfSecondSemesterData[0, 12]?.ToString(),
                Another = hoursCalculationOfSecondSemesterData[0, 13]?.ToString(),
                All = hoursCalculationOfSecondSemesterData[0, 14]?.ToString(),
                Active = hoursCalculationOfSecondSemesterData[0, 15]?.ToString(),
                Bonus = hoursCalculationOfSecondSemesterData[0, 17]?.ToString()
            };

        #endregion

        #region Semesters

        private static FirstSemesterDto GetFirstSemesterData(object[,] firstSemesterData) =>
            new FirstSemesterDto
            {
                Hours = firstSemesterData[0, 0]?.ToString(),
                HoursAll = firstSemesterData[0, 1]?.ToString(),
                Lectures = firstSemesterData[0, 2]?.ToString(),
                Laboratory = firstSemesterData[0, 3]?.ToString(),
                Practical = firstSemesterData[0, 4]?.ToString(),
                IndividualWork = firstSemesterData[0, 5]?.ToString(),
                CourseWork = firstSemesterData[0, 6]?.ToString(),
                Exam = firstSemesterData[0, 7]?.ToString(),
                Credit = firstSemesterData[0, 8]?.ToString()
            };

        private static SecondSemesterDto GetSecondSemesterData(object[,] secondSemesterData) =>
            new SecondSemesterDto
            {
                Hours = secondSemesterData[0, 0]?.ToString(),
                HoursAll = secondSemesterData[0, 1]?.ToString(),
                Lectures = secondSemesterData[0, 2]?.ToString(),
                Laboratory = secondSemesterData[0, 3]?.ToString(),
                Practical = secondSemesterData[0, 4]?.ToString(),
                IndividualWork = secondSemesterData[0, 5]?.ToString(),
                CourseWork = secondSemesterData[0, 6]?.ToString(),
                Exam = secondSemesterData[0, 7]?.ToString(),
                Credit = secondSemesterData[0, 8]?.ToString()
            };

        #endregion

        #region EntryLoads

        private FullTimeEntryLoadDto GetFullEntryLoadData(object[,] entryLoadData, object[,] entryLoadHoursData,
            object[,] entryLoadNormsData,
            FullTimeDisciplineDto fullTimeDiscipline,
            HoursCalculationOfFirstSemesterDto hoursCalculationOfFirstSemester,
            HoursCalculationOfSecondSemesterDto hoursCalculationOfSecondSemester) =>
            new FullTimeEntryLoadDto
            {
                Faculty = this._faculties.SingleOrDefault(f =>
                    f.CodeFaculty.Equals(entryLoadData[0, 0]?.ToString().ToLower())),
                Specialty = entryLoadData[0, 1]?.ToString(),
                Specialization = entryLoadData[0, 2]?.ToString(),
                Course = entryLoadData[0, 3]?.ToString(),
                EducationalDegree = entryLoadData[0, 4]?.ToString(),
                AmountOfStudents = entryLoadData[0, 5]?.ToString(),
                AmountOfForeignersStudents = entryLoadData[0, 6]?.ToString(),
                GroupCode = entryLoadData[0, 7]?.ToString(),
                NumberOfGroups = entryLoadData[0, 8]?.ToString(),
                RealNumberOfGroups = entryLoadData[0, 9]?.ToString(),
                NumberOfSubGroups = entryLoadData[0, 10]?.ToString(),
                AmountOfStudentsStreams = entryLoadData[0, 11]?.ToString(),
                ConnectingOfStudentStreams = entryLoadData[0, 12]?.ToString(),
                Notes = entryLoadData[0, 13]?.ToString(),
                FullTimeDiscipline = fullTimeDiscipline,
                HoursCalculationOfFirstSemester = hoursCalculationOfFirstSemester.All == null
                    ? null
                    : hoursCalculationOfFirstSemester,
                HoursCalculationOfSecondSemester = hoursCalculationOfSecondSemester.All == null
                    ? null
                    : hoursCalculationOfSecondSemester,
                KRKPDR = entryLoadNormsData[0, 0]?.ToString(),
                Practical = entryLoadNormsData[0, 1]?.ToString(),
                AmountOfPeopleDec = entryLoadNormsData[0, 2]?.ToString(),
                All = entryLoadHoursData[0, 0]?.ToString(),
                Active = entryLoadHoursData[0, 1]?.ToString()
            };

        private static PartTimeEntryLoadDto GetPartTimeEntryLoadData(object[,] entryLoadData,
            object[,] entryLoadHoursData,
            PartTimeDisciplineDto discipline,
            HoursCalculationOfFirstSemesterDto hoursCalculationOfFirstSemester,
            HoursCalculationOfSecondSemesterDto hoursCalculationOfSecondSemester) =>
            new PartTimeEntryLoadDto
            {
                Unit = entryLoadData[0, 0]?.ToString(),
                Specialty = entryLoadData[0, 1]?.ToString(),
                Specialization = entryLoadData[0, 2]?.ToString(),
                Course = entryLoadData[0, 3]?.ToString(),
                EducationalDegree = entryLoadData[0, 4]?.ToString(),
                AmountOfStudents = entryLoadData[0, 5]?.ToString(),
                NumberOfGroups = entryLoadData[0, 6]?.ToString(),
                AmountOfStudentsStreams = entryLoadData[0, 7]?.ToString(),
                ConnectingOfStudentStreams = entryLoadData[0, 8]?.ToString(),
                MainSpecial = entryLoadData[0, 9]?.ToString(),
                NumberOfConstituentSession = entryLoadData[0, 10]?.ToString(),
                NumberOfExaminationSession = entryLoadData[0, 11]?.ToString(),
                PartTimeDiscipline = discipline,
                HoursCalculationOfFirstSemester = hoursCalculationOfFirstSemester.All == null
                    ? null
                    : hoursCalculationOfFirstSemester,
                HoursCalculationOfSecondSemester = hoursCalculationOfSecondSemester.All == null
                    ? null
                    : hoursCalculationOfSecondSemester,
                All = entryLoadHoursData[0, 0]?.ToString(),
                Active = entryLoadHoursData[0, 1]?.ToString()
            };

        #endregion

        #region Discipline

        private FullTimeDisciplineDto GetFullTimeDisciplineData(object[,] disciplineData,
            FirstSemesterDto firstSemester,
            SecondSemesterDto secondSemester, object[,] codeDepartmentData) =>
            new FullTimeDisciplineDto
            {
                Name = disciplineData[0, 0]?.ToString(),
                ECTS = disciplineData[0, 1]?.ToString(),
                AmountOfHours = disciplineData[0, 2]?.ToString(),
                Language = disciplineData[0, 3]?.ToString(),
                WeeksInFirstSemester = disciplineData[0, 4]?.ToString(),
                WeeksInSecondSemester = disciplineData[0, 5]?.ToString(),
                FirstSemester = firstSemester.Hours == null ? null : firstSemester,
                SecondSemester = secondSemester.Hours == null ? null : secondSemester,
                Department = this._departments.SingleOrDefault(d =>
                    d.CodeDepartment.Equals(codeDepartmentData[0, 0]?.ToString().ToLower()))
            };

        private PartTimeDisciplineDto GetPartTimeDisciplineData(object[,] disciplineData,
            ConstituentSessionDto constituentSession,
            ExaminationSessionDto examinationSession, object[,] codeDepartmentData) =>
            new PartTimeDisciplineDto
            {
                Name = disciplineData[0, 0]?.ToString(),
                ECTS = disciplineData[0, 1]?.ToString(),
                AmountOfHours = disciplineData[0, 2]?.ToString(),
                KRKPDR = disciplineData[0, 3]?.ToString(),
                Language = disciplineData[0, 4]?.ToString(),
                NumberOfDeaneryMembers = disciplineData[0, 5]?.ToString(),
                ConstituentSession = constituentSession.Hours == null ? null : constituentSession,
                ExaminationSession = examinationSession.Hours == null ? null : examinationSession,
                Department = this._departments.SingleOrDefault(d =>
                    d.CodeDepartment.Equals(codeDepartmentData[0, 0]?.ToString().ToLower()))
            };

        #endregion

        #region Session

        private static ConstituentSessionDto GetConstituentSessionData(object[,] constituentSessionData) =>
            new ConstituentSessionDto
            {
                Hours = constituentSessionData[0, 0]?.ToString(),
                HoursAll = constituentSessionData[0, 1]?.ToString(),
                Lectures = constituentSessionData[0, 2]?.ToString(),
                Laboratory = constituentSessionData[0, 3]?.ToString(),
                Practical = constituentSessionData[0, 4]?.ToString(),
                IndividualWork = constituentSessionData[0, 5]?.ToString(),
                CourseWork = constituentSessionData[0, 6]?.ToString(),
                ControlWork = constituentSessionData[0, 7]?.ToString(),
                Exam = constituentSessionData[0, 8]?.ToString(),
                Credit = constituentSessionData[0, 9]?.ToString()
            };

        private static ExaminationSessionDto GetExaminationSessionData(object[,] examinationSessionData) =>
            new ExaminationSessionDto
            {
                Hours = examinationSessionData[0, 0]?.ToString(),
                HoursAll = examinationSessionData[0, 1]?.ToString(),
                Lectures = examinationSessionData[0, 2]?.ToString(),
                Laboratory = examinationSessionData[0, 3]?.ToString(),
                Practical = examinationSessionData[0, 4]?.ToString(),
                IndividualWork = examinationSessionData[0, 5]?.ToString(),
                CourseWork = examinationSessionData[0, 6]?.ToString(),
                ControlWork = examinationSessionData[0, 7]?.ToString(),
                Exam = examinationSessionData[0, 8]?.ToString(),
                Credit = examinationSessionData[0, 9]?.ToString()
            };

        #endregion

        #endregion

        #region InsertToDb

        private async Task InsertData(FirstSemesterDto firstSemester,
            SecondSemesterDto secondSemester, FullTimeDisciplineDto fullTimeDiscipline,
            HoursCalculationOfFirstSemesterDto hoursCalculationOfFirstSemester,
            HoursCalculationOfSecondSemesterDto hoursCalculationOfSecondSemester,
            FullTimeEntryLoadDto fullTimeEntryLoad)
        {
            if (firstSemester.Hours != null)
                firstSemester.Id =
                    await this.Uow.FirstSemesterRepository.InsertFirstSemester(
                        this.Mapper.Map<FirstSemester>(firstSemester));

            if (secondSemester.Hours != null)
                secondSemester.Id =
                    await this.Uow.SecondSemesterRepository.InsertSecondSemester(
                        this.Mapper.Map<SecondSemester>(secondSemester));

            fullTimeDiscipline.Id =
                await this.Uow.FullTimeDisciplineRepository.InsertFullTimeDiscipline(
                    this.Mapper.Map<FullTimeDiscipline>(fullTimeDiscipline));

            if (hoursCalculationOfFirstSemester.All != null)
                hoursCalculationOfFirstSemester.Id =
                    await this.Uow.HoursCalculationOfFirstSemesterRepository
                        .InsertHoursCalculationOfFirstSemester(
                            this.Mapper.Map<HoursCalculationOfFirstSemester>(hoursCalculationOfFirstSemester));

            if (hoursCalculationOfSecondSemester.All != null)
                hoursCalculationOfSecondSemester.Id =
                    await this.Uow.HoursCalculationOfSecondSemesterRepository
                        .InsertHoursCalculationOfSecondSemester(
                            this.Mapper.Map<HoursCalculationOfSecondSemester>(hoursCalculationOfSecondSemester));

            await this.Uow.FullTimeEntryLoadRepository.InsertFullTimeEntryLoad(
                this.Mapper.Map<FullTimeEntryLoad>(fullTimeEntryLoad));
        }

        private async Task InsertData(ConstituentSessionDto constituentSession,
            ExaminationSessionDto examinationSession,
            PartTimeDisciplineDto discipline,
            HoursCalculationOfFirstSemesterDto hoursCalculationOfFirstSemester,
            HoursCalculationOfSecondSemesterDto hoursCalculationOfSecondSemester,
            PartTimeEntryLoadDto entryLoad)
        {
            if (constituentSession.Hours != null)
                constituentSession.Id =
                    await this.Uow.ConstituentSessionRepository.InsertConstituentSession(
                        this.Mapper.Map<ConstituentSession>(constituentSession));

            if (examinationSession.Hours != null)
                examinationSession.Id =
                    await this.Uow.ExaminationSessionRepository.InsertExaminationSession(
                        this.Mapper.Map<ExaminationSession>(examinationSession));

            discipline.Id =
                await this.Uow.PartTimeDisciplineRepository.InsertPartTimeDiscipline(
                    this.Mapper.Map<PartTimeDiscipline>(discipline));

            if (hoursCalculationOfFirstSemester.All != null)
                hoursCalculationOfFirstSemester.Id =
                    await this.Uow.HoursCalculationOfFirstSemesterRepository
                        .InsertHoursCalculationOfFirstSemester(
                            this.Mapper.Map<HoursCalculationOfFirstSemester>(hoursCalculationOfFirstSemester));

            if (hoursCalculationOfSecondSemester.All != null)
                hoursCalculationOfSecondSemester.Id =
                    await this.Uow.HoursCalculationOfSecondSemesterRepository
                        .InsertHoursCalculationOfSecondSemester(
                            this.Mapper.Map<HoursCalculationOfSecondSemester>(hoursCalculationOfSecondSemester));

            await this.Uow.PartTimeEntryLoadRepository.InsertPartTimeEntryLoad(
                this.Mapper.Map<PartTimeEntryLoad>(entryLoad));
        }

        #endregion

        #endregion
    }
}