using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Planner.Data.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<string>(nullable: false),
                    Literal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "ExternalCollaborator",
                columns: table => new
                {
                    ExternalCollaboratorId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalCollaborator", x => x.ExternalCollaboratorId);
                });

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    FacultyId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.FacultyId);
                });

            migrationBuilder.CreateTable(
                name: "IndPlanType",
                columns: table => new
                {
                    IndPlanTypeId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndPlanType", x => x.IndPlanTypeId);
                });

            migrationBuilder.CreateTable(
                name: "NMBD",
                columns: table => new
                {
                    NMBDId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NMBD", x => x.NMBDId);
                });

            migrationBuilder.CreateTable(
                name: "Publication",
                columns: table => new
                {
                    PublicationId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    Pages = table.Column<double>(nullable: true),
                    Output = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    PublishedAt = table.Column<DateTime>(nullable: true),
                    IsPublished = table.Column<bool>(nullable: false),
                    IsOverseas = table.Column<bool>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true),
                    CitationNumberNMBD = table.Column<int>(nullable: false),
                    ImpactFactorNMBD = table.Column<double>(nullable: false),
                    ResearchDoneTypeId = table.Column<int>(nullable: false),
                    StoringTypeId = table.Column<int>(nullable: false),
                    PublicationTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publication", x => x.PublicationId);
                });

            migrationBuilder.CreateTable(
                name: "Rate",
                columns: table => new
                {
                    RateId = table.Column<string>(nullable: false),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate", x => x.RateId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Specialize",
                columns: table => new
                {
                    SpecializeId = table.Column<string>(nullable: false),
                    Cipher = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialize", x => x.SpecializeId);
                });

            migrationBuilder.CreateTable(
                name: "Specialty",
                columns: table => new
                {
                    SpecialtyId = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialty", x => x.SpecialtyId);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<double>(nullable: false),
                    FacultyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Department_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "FacultyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndivPlanFields",
                columns: table => new
                {
                    IndivPlanFieldsId = table.Column<string>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    SchemaName = table.Column<string>(nullable: true),
                    Suffix = table.Column<string>(nullable: true),
                    TabName = table.Column<string>(nullable: true),
                    IndPlanTypeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndivPlanFields", x => x.IndivPlanFieldsId);
                    table.ForeignKey(
                        name: "FK_IndivPlanFields_IndPlanType_IndPlanTypeId",
                        column: x => x.IndPlanTypeId,
                        principalTable: "IndPlanType",
                        principalColumn: "IndPlanTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PublicationNMBD",
                columns: table => new
                {
                    PublicationNMBDId = table.Column<string>(nullable: false),
                    PublicationId = table.Column<string>(nullable: true),
                    NMBDId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationNMBD", x => x.PublicationNMBDId);
                    table.ForeignKey(
                        name: "FK_PublicationNMBD_NMBD_NMBDId",
                        column: x => x.NMBDId,
                        principalTable: "NMBD",
                        principalColumn: "NMBDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PublicationNMBD_Publication_PublicationId",
                        column: x => x.PublicationId,
                        principalTable: "Publication",
                        principalColumn: "PublicationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoadingList",
                columns: table => new
                {
                    LoadingListId = table.Column<string>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadingList", x => x.LoadingListId);
                    table.ForeignKey(
                        name: "FK_LoadingList_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleId = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    ApiId = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedule_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DayEntryLoad",
                columns: table => new
                {
                    DayEntryLoadId = table.Column<string>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    EducationDegree = table.Column<string>(nullable: true),
                    ConflatedThreads = table.Column<string>(nullable: true),
                    CountOfCredits = table.Column<double>(nullable: false),
                    CountOfHours = table.Column<double>(nullable: false),
                    HoursPerCredit = table.Column<double>(nullable: false),
                    FSemCoefficient = table.Column<double>(nullable: false),
                    SSemCoefficient = table.Column<double>(nullable: false),
                    F_TotalHour = table.Column<double>(nullable: false),
                    F_Total = table.Column<double>(nullable: false),
                    F_Lectures = table.Column<double>(nullable: false),
                    F_Labs = table.Column<double>(nullable: false),
                    F_Practical = table.Column<double>(nullable: false),
                    F_IndividualWork = table.Column<double>(nullable: false),
                    F_CourseProjects = table.Column<string>(nullable: true),
                    F_Exams = table.Column<string>(nullable: true),
                    F_Evaluation = table.Column<string>(nullable: true),
                    S_TotalHour = table.Column<double>(nullable: false),
                    S_Total = table.Column<double>(nullable: false),
                    S_Lectures = table.Column<double>(nullable: false),
                    S_Labs = table.Column<double>(nullable: false),
                    S_Practical = table.Column<double>(nullable: false),
                    S_IndividualWork = table.Column<double>(nullable: false),
                    S_CourseProjects = table.Column<string>(nullable: true),
                    S_Exams = table.Column<string>(nullable: true),
                    S_Evaluation = table.Column<string>(nullable: true),
                    DepartmentCipher = table.Column<string>(nullable: true),
                    FS_CountOfWeeks = table.Column<double>(nullable: false),
                    SS_CountOfWeeks = table.Column<double>(nullable: false),
                    QuantityOfStudents = table.Column<double>(nullable: false),
                    QuantityOfForeigners = table.Column<double>(nullable: false),
                    CipherOfGroups = table.Column<string>(nullable: true),
                    QuantityOfGroupsCritOne = table.Column<double>(nullable: false),
                    RealQuantityOfGroups = table.Column<double>(nullable: false),
                    QuantityOfGroupsCritTwo = table.Column<double>(nullable: false),
                    QuantityOfThreads = table.Column<double>(nullable: false),
                    CipherOfThreads = table.Column<double>(nullable: false),
                    KR_KP_DR = table.Column<double>(nullable: false),
                    Practice = table.Column<double>(nullable: false),
                    QuantityOfDek = table.Column<double>(nullable: false),
                    FacultyName = table.Column<string>(nullable: true),
                    LoadingListId = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<string>(nullable: true),
                    SpecialtyId = table.Column<string>(nullable: true),
                    SpecializeId = table.Column<string>(nullable: true),
                    CourseId = table.Column<string>(nullable: true),
                    SubjectId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayEntryLoad", x => x.DayEntryLoadId);
                    table.ForeignKey(
                        name: "FK_DayEntryLoad_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayEntryLoad_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayEntryLoad_LoadingList_LoadingListId",
                        column: x => x.LoadingListId,
                        principalTable: "LoadingList",
                        principalColumn: "LoadingListId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayEntryLoad_Specialize_SpecializeId",
                        column: x => x.SpecializeId,
                        principalTable: "Specialize",
                        principalColumn: "SpecializeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayEntryLoad_Specialty_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialty",
                        principalColumn: "SpecialtyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayEntryLoad_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DDataStorage",
                columns: table => new
                {
                    DDataStorageId = table.Column<string>(nullable: false),
                    Semester = table.Column<int>(nullable: false),
                    N = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    Faculty = table.Column<string>(nullable: true),
                    Specialty = table.Column<string>(nullable: true),
                    Specialize = table.Column<string>(nullable: true),
                    Course = table.Column<string>(nullable: true),
                    EduDegree = table.Column<string>(nullable: true),
                    CountOfStud = table.Column<double>(nullable: false),
                    CipherOfGroup = table.Column<string>(nullable: true),
                    QuanOfGroupCritOne = table.Column<double>(nullable: false),
                    RealQuanGr = table.Column<double>(nullable: false),
                    QuanOfGroupCritTwo = table.Column<string>(nullable: true),
                    QuanOfThread = table.Column<double>(nullable: false),
                    TotalHour = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    Lecture = table.Column<double>(nullable: false),
                    Practice = table.Column<double>(nullable: false),
                    Lab = table.Column<double>(nullable: false),
                    IndWork = table.Column<double>(nullable: false),
                    CourseProjects = table.Column<string>(nullable: true),
                    Exam = table.Column<string>(nullable: true),
                    Eval = table.Column<string>(nullable: true),
                    CLecture = table.Column<double>(nullable: false),
                    CPractice = table.Column<double>(nullable: false),
                    CLab = table.Column<double>(nullable: false),
                    CConsultInSem = table.Column<double>(nullable: false),
                    CConsultForExam = table.Column<double>(nullable: false),
                    CCheckOfTests = table.Column<double>(nullable: false),
                    CKR_KP = table.Column<double>(nullable: false),
                    CEval = table.Column<double>(nullable: false),
                    CExam = table.Column<double>(nullable: false),
                    CPracticePreparation = table.Column<double>(nullable: false),
                    CDek = table.Column<double>(nullable: false),
                    CStateExam = table.Column<double>(nullable: false),
                    CManagedDiploma = table.Column<double>(nullable: false),
                    COther = table.Column<double>(nullable: false),
                    CTotal = table.Column<double>(nullable: false),
                    CActive = table.Column<double>(nullable: false),
                    LoadingListId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDataStorage", x => x.DDataStorageId);
                    table.ForeignKey(
                        name: "FK_DDataStorage_LoadingList_LoadingListId",
                        column: x => x.LoadingListId,
                        principalTable: "LoadingList",
                        principalColumn: "LoadingListId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EDataStorage",
                columns: table => new
                {
                    EDataStorageId = table.Column<string>(nullable: false),
                    Semester = table.Column<int>(nullable: false),
                    N = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    Specialty = table.Column<string>(nullable: true),
                    Extramural = table.Column<string>(nullable: true),
                    Course = table.Column<double>(nullable: false),
                    QuanOfStud = table.Column<double>(nullable: false),
                    QuanOfThread = table.Column<double>(nullable: false),
                    CommonTime = table.Column<double>(nullable: false),
                    Lecture = table.Column<double>(nullable: false),
                    Practice = table.Column<double>(nullable: false),
                    Lab = table.Column<double>(nullable: false),
                    IndWork = table.Column<double>(nullable: false),
                    Exam = table.Column<string>(nullable: true),
                    Eval = table.Column<string>(nullable: true),
                    Test = table.Column<double>(nullable: false),
                    NormKR_KP = table.Column<double>(nullable: false),
                    CLecture = table.Column<double>(nullable: false),
                    CPractice = table.Column<double>(nullable: false),
                    CLab = table.Column<double>(nullable: false),
                    CConsultInSem = table.Column<double>(nullable: false),
                    CConsultForExam = table.Column<double>(nullable: false),
                    CVerifyingTest = table.Column<double>(nullable: false),
                    CCourseProject = table.Column<double>(nullable: false),
                    CEval = table.Column<double>(nullable: false),
                    COralExam = table.Column<double>(nullable: false),
                    CManagedDiploma = table.Column<double>(nullable: false),
                    CDek = table.Column<double>(nullable: false),
                    CVerifyingOfWrWork = table.Column<double>(nullable: false),
                    CProtection = table.Column<double>(nullable: false),
                    CTotal = table.Column<double>(nullable: false),
                    CActive = table.Column<double>(nullable: false),
                    LoadingListId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDataStorage", x => x.EDataStorageId);
                    table.ForeignKey(
                        name: "FK_EDataStorage_LoadingList_LoadingListId",
                        column: x => x.LoadingListId,
                        principalTable: "LoadingList",
                        principalColumn: "LoadingListId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExtramuralEntryLoad",
                columns: table => new
                {
                    ExtramuralEntryLoadId = table.Column<string>(nullable: false),
                    DepartmentCipher = table.Column<string>(nullable: true),
                    Extramural = table.Column<string>(nullable: true),
                    Course = table.Column<double>(nullable: false),
                    QuantityOfStudents = table.Column<double>(nullable: false),
                    QuantityOfGroups = table.Column<double>(nullable: false),
                    QuantityOfThreads = table.Column<double>(nullable: false),
                    NumOfThread = table.Column<double>(nullable: false),
                    MajorSpecialty = table.Column<string>(nullable: true),
                    CommonTime = table.Column<double>(nullable: false),
                    Credits = table.Column<double>(nullable: false),
                    F_Lecture = table.Column<double>(nullable: false),
                    F_Practical = table.Column<double>(nullable: false),
                    F_Lab = table.Column<double>(nullable: false),
                    F_IndividualWork = table.Column<double>(nullable: false),
                    F_Exam = table.Column<string>(nullable: true),
                    F_Evaluation = table.Column<string>(nullable: true),
                    F_KR = table.Column<string>(nullable: true),
                    F_Test = table.Column<double>(nullable: false),
                    F_LimitOnProjects = table.Column<double>(nullable: false),
                    S_Lecture = table.Column<double>(nullable: false),
                    S_Practical = table.Column<double>(nullable: false),
                    S_Lab = table.Column<double>(nullable: false),
                    S_IndividualWork = table.Column<double>(nullable: false),
                    S_Exam = table.Column<string>(nullable: true),
                    S_Evaluation = table.Column<string>(nullable: true),
                    S_KR = table.Column<string>(nullable: true),
                    S_Test = table.Column<double>(nullable: false),
                    S_LimitOnProjects = table.Column<double>(nullable: false),
                    LoadingListId = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<string>(nullable: true),
                    SubjectId = table.Column<string>(nullable: true),
                    SpecialtyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtramuralEntryLoad", x => x.ExtramuralEntryLoadId);
                    table.ForeignKey(
                        name: "FK_ExtramuralEntryLoad_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExtramuralEntryLoad_LoadingList_LoadingListId",
                        column: x => x.LoadingListId,
                        principalTable: "LoadingList",
                        principalColumn: "LoadingListId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExtramuralEntryLoad_Specialty_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialty",
                        principalColumn: "SpecialtyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExtramuralEntryLoad_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ThirdName = table.Column<string>(nullable: true),
                    ScholarLink = table.Column<string>(nullable: true),
                    ProfilePicture = table.Column<byte[]>(nullable: true),
                    BasicOrCompatible = table.Column<string>(nullable: true),
                    Document = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    OrcidLink = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    LockoutEndDateUtc = table.Column<DateTime>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    AcademicTitleId = table.Column<int>(nullable: false),
                    DegreeId = table.Column<int>(nullable: false),
                    PositionId = table.Column<int>(nullable: false),
                    ScheduleId = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.ApplicationUserId);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DaySemester",
                columns: table => new
                {
                    DaySemesterId = table.Column<string>(nullable: false),
                    Semester = table.Column<byte>(nullable: false),
                    Lecture = table.Column<double>(nullable: false),
                    Practice = table.Column<double>(nullable: false),
                    Lab = table.Column<double>(nullable: false),
                    ConsultInSemester = table.Column<double>(nullable: false),
                    ConsultForExam = table.Column<double>(nullable: false),
                    VerifyingOfTests = table.Column<double>(nullable: false),
                    KR_KP = table.Column<double>(nullable: false),
                    ControlEvaluation = table.Column<double>(nullable: false),
                    ControlExam = table.Column<double>(nullable: false),
                    PracticePreparation = table.Column<double>(nullable: false),
                    Dek = table.Column<double>(nullable: false),
                    StateExam = table.Column<double>(nullable: false),
                    ManagedDiploma = table.Column<double>(nullable: false),
                    Other = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    Active = table.Column<double>(nullable: false),
                    EnglishBonus = table.Column<double>(nullable: false),
                    DayEntryLoadId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaySemester", x => x.DaySemesterId);
                    table.ForeignKey(
                        name: "FK_DaySemester_DayEntryLoad_DayEntryLoadId",
                        column: x => x.DayEntryLoadId,
                        principalTable: "DayEntryLoad",
                        principalColumn: "DayEntryLoadId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExtramuralSemester",
                columns: table => new
                {
                    ExtramuralSemesterId = table.Column<string>(nullable: false),
                    Semester = table.Column<int>(nullable: false),
                    Lecture = table.Column<double>(nullable: false),
                    Practice = table.Column<double>(nullable: false),
                    Lab = table.Column<double>(nullable: false),
                    ConsultInSemester = table.Column<double>(nullable: false),
                    ConsultForExam = table.Column<double>(nullable: false),
                    WrittenWork = table.Column<double>(nullable: false),
                    CalcWorks = table.Column<double>(nullable: false),
                    CourseProjects = table.Column<double>(nullable: false),
                    Evaluation = table.Column<double>(nullable: false),
                    OralExam = table.Column<double>(nullable: false),
                    WrittenExam = table.Column<double>(nullable: false),
                    VerifyingOfTest = table.Column<double>(nullable: false),
                    ManagedDiploma = table.Column<double>(nullable: false),
                    Dek = table.Column<double>(nullable: false),
                    VerifyingOfWrittenWorks = table.Column<double>(nullable: false),
                    Protection = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    Active = table.Column<double>(nullable: false),
                    ExtramuralEntryLoadId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtramuralSemester", x => x.ExtramuralSemesterId);
                    table.ForeignKey(
                        name: "FK_ExtramuralSemester_ExtramuralEntryLoad_ExtramuralEntryLoadId",
                        column: x => x.ExtramuralEntryLoadId,
                        principalTable: "ExtramuralEntryLoad",
                        principalColumn: "ExtramuralEntryLoadId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DayTeachLoad",
                columns: table => new
                {
                    DayTeachLoadId = table.Column<string>(nullable: false),
                    Semester = table.Column<int>(nullable: false),
                    Specialty = table.Column<string>(nullable: true),
                    Course = table.Column<double>(nullable: false),
                    Lecture = table.Column<double>(nullable: false),
                    Practice = table.Column<double>(nullable: false),
                    Lab = table.Column<double>(nullable: false),
                    ConsultInSemester = table.Column<double>(nullable: false),
                    ConsultForExam = table.Column<double>(nullable: false),
                    WrittenWork = table.Column<double>(nullable: false),
                    CalcWorks = table.Column<double>(nullable: false),
                    CourseProjects = table.Column<double>(nullable: false),
                    Evaluation = table.Column<double>(nullable: false),
                    OralExam = table.Column<double>(nullable: false),
                    WrittenExam = table.Column<double>(nullable: false),
                    VerifyingOfTest = table.Column<double>(nullable: false),
                    ManagedDiploma = table.Column<double>(nullable: false),
                    Dek = table.Column<double>(nullable: false),
                    VerifyingOfWrittenWorks = table.Column<double>(nullable: false),
                    Protection = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    Active = table.Column<double>(nullable: false),
                    SubjectId = table.Column<string>(nullable: true),
                    DayEntryLoadId = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayTeachLoad", x => x.DayTeachLoadId);
                    table.ForeignKey(
                        name: "FK_DayTeachLoad_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayTeachLoad_DayEntryLoad_DayEntryLoadId",
                        column: x => x.DayEntryLoadId,
                        principalTable: "DayEntryLoad",
                        principalColumn: "DayEntryLoadId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayTeachLoad_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentUser",
                columns: table => new
                {
                    DepartmentUserId = table.Column<string>(nullable: false),
                    RateId = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentUser", x => x.DepartmentUserId);
                    table.ForeignKey(
                        name: "FK_DepartmentUser_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentUser_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentUser_Rate_RateId",
                        column: x => x.RateId,
                        principalTable: "Rate",
                        principalColumn: "RateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExtramuralTeachLoad",
                columns: table => new
                {
                    ExtramuralTeachLoadId = table.Column<string>(nullable: false),
                    Semester = table.Column<int>(nullable: false),
                    Specialty = table.Column<string>(nullable: true),
                    Course = table.Column<double>(nullable: false),
                    Lecture = table.Column<double>(nullable: false),
                    Practice = table.Column<double>(nullable: false),
                    Lab = table.Column<double>(nullable: false),
                    ConsultInSemester = table.Column<double>(nullable: false),
                    ConsultForExam = table.Column<double>(nullable: false),
                    WrittenWork = table.Column<double>(nullable: false),
                    CalcWorks = table.Column<double>(nullable: false),
                    CourseProjects = table.Column<double>(nullable: false),
                    Evaluation = table.Column<double>(nullable: false),
                    OralExam = table.Column<double>(nullable: false),
                    WrittenExam = table.Column<double>(nullable: false),
                    VerifyingOfTest = table.Column<double>(nullable: false),
                    ManagedDiploma = table.Column<double>(nullable: false),
                    Dek = table.Column<double>(nullable: false),
                    VerifyingOfWrittenWorks = table.Column<double>(nullable: false),
                    Protection = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    Active = table.Column<double>(nullable: false),
                    SubjectId = table.Column<string>(nullable: true),
                    ExtramuralEntryLoadId = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtramuralTeachLoad", x => x.ExtramuralTeachLoadId);
                    table.ForeignKey(
                        name: "FK_ExtramuralTeachLoad_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExtramuralTeachLoad_ExtramuralEntryLoad_ExtramuralEntryLoadId",
                        column: x => x.ExtramuralEntryLoadId,
                        principalTable: "ExtramuralEntryLoad",
                        principalColumn: "ExtramuralEntryLoadId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExtramuralTeachLoad_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndivPlanFieldsValue",
                columns: table => new
                {
                    IndivPlanFieldsValueId = table.Column<string>(nullable: false),
                    SchemaName = table.Column<string>(nullable: true),
                    Result = table.Column<string>(nullable: true),
                    PlannedValue = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndivPlanFieldsValue", x => x.IndivPlanFieldsValueId);
                    table.ForeignKey(
                        name: "FK_IndivPlanFieldsValue_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NDR",
                columns: table => new
                {
                    NDRId = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Step = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    StudentName = table.Column<string>(nullable: true),
                    Awards = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NDR", x => x.NDRId);
                    table.ForeignKey(
                        name: "FK_NDR_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanChange",
                columns: table => new
                {
                    PlanChangeId = table.Column<string>(nullable: false),
                    Semester = table.Column<int>(nullable: false),
                    TypesfJobs = table.Column<string>(nullable: true),
                    Changes = table.Column<string>(nullable: true),
                    PlannedVolume = table.Column<int>(nullable: false),
                    ActualVolume = table.Column<int>(nullable: false),
                    Base = table.Column<string>(nullable: true),
                    Signature = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanChange", x => x.PlanChangeId);
                    table.ForeignKey(
                        name: "FK_PlanChange_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanConclusion",
                columns: table => new
                {
                    PlanConclusionId = table.Column<string>(nullable: false),
                    Semester = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Signature = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanConclusion", x => x.PlanConclusionId);
                    table.ForeignKey(
                        name: "FK_PlanConclusion_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanManagment",
                columns: table => new
                {
                    PlanManagmentId = table.Column<string>(nullable: false),
                    OrderNumber = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Result = table.Column<string>(nullable: true),
                    DurationTime = table.Column<int>(nullable: false),
                    PlannedVolume = table.Column<int>(nullable: false),
                    ActualVolume = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanManagment", x => x.PlanManagmentId);
                    table.ForeignKey(
                        name: "FK_PlanManagment_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanMethodicalWork",
                columns: table => new
                {
                    PlanMethodicalWorkId = table.Column<string>(nullable: false),
                    OrderNumber = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Result = table.Column<string>(nullable: true),
                    DurationTime = table.Column<int>(nullable: false),
                    PlannedVolume = table.Column<int>(nullable: false),
                    ActualVolume = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanMethodicalWork", x => x.PlanMethodicalWorkId);
                    table.ForeignKey(
                        name: "FK_PlanMethodicalWork_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanRemark",
                columns: table => new
                {
                    PlanRemarkId = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    Signature = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanRemark", x => x.PlanRemarkId);
                    table.ForeignKey(
                        name: "FK_PlanRemark_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanTrainingJob",
                columns: table => new
                {
                    PlanTrainingJobId = table.Column<string>(nullable: false),
                    EducationForm = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    DSD = table.Column<string>(nullable: true),
                    Course = table.Column<int>(nullable: false),
                    CountStudent = table.Column<int>(nullable: false),
                    GroupCode = table.Column<string>(nullable: true),
                    PlannedLectures = table.Column<int>(nullable: false),
                    DoneLectures = table.Column<int>(nullable: false),
                    PlannedPract = table.Column<int>(nullable: false),
                    DonePract = table.Column<int>(nullable: false),
                    PlannedLaboratory = table.Column<int>(nullable: false),
                    DoneLaboratory = table.Column<int>(nullable: false),
                    PlannedSeminar = table.Column<int>(nullable: false),
                    DoneSeminar = table.Column<int>(nullable: false),
                    PlannedIndividual = table.Column<int>(nullable: false),
                    DoneIndividual = table.Column<int>(nullable: false),
                    PlannedConsultation = table.Column<int>(nullable: false),
                    DoneConsultation = table.Column<int>(nullable: false),
                    PlannedExamConsultation = table.Column<int>(nullable: false),
                    DoneExamConsultation = table.Column<int>(nullable: false),
                    PlannedCheckControl = table.Column<int>(nullable: false),
                    DoneCheckControl = table.Column<int>(nullable: false),
                    PlannedCheckLectureControl = table.Column<int>(nullable: false),
                    DoneCheckLectureControl = table.Column<int>(nullable: false),
                    PlannedEAT = table.Column<int>(nullable: false),
                    DoneEAT = table.Column<int>(nullable: false),
                    PlannedCGS = table.Column<int>(nullable: false),
                    DoneCGS = table.Column<int>(nullable: false),
                    PlannedCoursework = table.Column<int>(nullable: false),
                    DoneCoursework = table.Column<int>(nullable: false),
                    PlannedOffsetting = table.Column<int>(nullable: false),
                    DoneOffsetting = table.Column<int>(nullable: false),
                    PlannedSemestrExam = table.Column<int>(nullable: false),
                    DoneSemestrExam = table.Column<int>(nullable: false),
                    PlannedTrainingPract = table.Column<int>(nullable: false),
                    DoneTrainingPract = table.Column<int>(nullable: false),
                    PlannedStateExam = table.Column<int>(nullable: false),
                    DoneStateExam = table.Column<int>(nullable: false),
                    PlannedDiploma = table.Column<int>(nullable: false),
                    DoneDiploma = table.Column<int>(nullable: false),
                    PlannedPostgraduates = table.Column<int>(nullable: false),
                    DonePostgraduates = table.Column<int>(nullable: false),
                    PlannedDEK = table.Column<int>(nullable: false),
                    DoneDEK = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanTrainingJob", x => x.PlanTrainingJobId);
                    table.ForeignKey(
                        name: "FK_PlanTrainingJob_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PublicationUser",
                columns: table => new
                {
                    PublicationUserId = table.Column<string>(nullable: false),
                    PageQuantity = table.Column<double>(nullable: false),
                    PublicationId = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    ExternalCollaboratorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationUser", x => x.PublicationUserId);
                    table.ForeignKey(
                        name: "FK_PublicationUser_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PublicationUser_ExternalCollaborator_ExternalCollaboratorId",
                        column: x => x.ExternalCollaboratorId,
                        principalTable: "ExternalCollaborator",
                        principalColumn: "ExternalCollaboratorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PublicationUser_Publication_PublicationId",
                        column: x => x.PublicationId,
                        principalTable: "Publication",
                        principalColumn: "PublicationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScientificPublishing",
                columns: table => new
                {
                    ScientificPublishingId = table.Column<string>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Monographs = table.Column<int>(nullable: false),
                    MonographsNationalPublications = table.Column<int>(nullable: false),
                    MonographsForeignJournals = table.Column<int>(nullable: false),
                    AllPublications = table.Column<int>(nullable: false),
                    ScientificPublicationsInScopus = table.Column<int>(nullable: false),
                    ArticlesThesesInNmbd = table.Column<int>(nullable: false),
                    ScientificPublicationsInForeignJournals = table.Column<int>(nullable: false),
                    ArticlesInProfessionalPublications = table.Column<int>(nullable: false),
                    ScientificArticlesInForeignLanguages = table.Column<int>(nullable: false),
                    Abstracts = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificPublishing", x => x.ScientificPublishingId);
                    table.ForeignKey(
                        name: "FK_ScientificPublishing_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_RoleId",
                table: "ApplicationUser",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_ScheduleId",
                table: "ApplicationUser",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_DayEntryLoad_CourseId",
                table: "DayEntryLoad",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_DayEntryLoad_DepartmentId",
                table: "DayEntryLoad",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DayEntryLoad_LoadingListId",
                table: "DayEntryLoad",
                column: "LoadingListId");

            migrationBuilder.CreateIndex(
                name: "IX_DayEntryLoad_SpecializeId",
                table: "DayEntryLoad",
                column: "SpecializeId");

            migrationBuilder.CreateIndex(
                name: "IX_DayEntryLoad_SpecialtyId",
                table: "DayEntryLoad",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_DayEntryLoad_SubjectId",
                table: "DayEntryLoad",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DaySemester_DayEntryLoadId",
                table: "DaySemester",
                column: "DayEntryLoadId");

            migrationBuilder.CreateIndex(
                name: "IX_DayTeachLoad_ApplicationUserId",
                table: "DayTeachLoad",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DayTeachLoad_DayEntryLoadId",
                table: "DayTeachLoad",
                column: "DayEntryLoadId");

            migrationBuilder.CreateIndex(
                name: "IX_DayTeachLoad_SubjectId",
                table: "DayTeachLoad",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DDataStorage_LoadingListId",
                table: "DDataStorage",
                column: "LoadingListId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_FacultyId",
                table: "Department",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentUser_ApplicationUserId",
                table: "DepartmentUser",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentUser_DepartmentId",
                table: "DepartmentUser",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentUser_RateId",
                table: "DepartmentUser",
                column: "RateId");

            migrationBuilder.CreateIndex(
                name: "IX_EDataStorage_LoadingListId",
                table: "EDataStorage",
                column: "LoadingListId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtramuralEntryLoad_DepartmentId",
                table: "ExtramuralEntryLoad",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtramuralEntryLoad_LoadingListId",
                table: "ExtramuralEntryLoad",
                column: "LoadingListId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtramuralEntryLoad_SpecialtyId",
                table: "ExtramuralEntryLoad",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtramuralEntryLoad_SubjectId",
                table: "ExtramuralEntryLoad",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtramuralSemester_ExtramuralEntryLoadId",
                table: "ExtramuralSemester",
                column: "ExtramuralEntryLoadId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtramuralTeachLoad_ApplicationUserId",
                table: "ExtramuralTeachLoad",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtramuralTeachLoad_ExtramuralEntryLoadId",
                table: "ExtramuralTeachLoad",
                column: "ExtramuralEntryLoadId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtramuralTeachLoad_SubjectId",
                table: "ExtramuralTeachLoad",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_IndivPlanFields_IndPlanTypeId",
                table: "IndivPlanFields",
                column: "IndPlanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IndivPlanFieldsValue_ApplicationUserId",
                table: "IndivPlanFieldsValue",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingList_DepartmentId",
                table: "LoadingList",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_NDR_ApplicationUserId",
                table: "NDR",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanChange_ApplicationUserId",
                table: "PlanChange",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanConclusion_ApplicationUserId",
                table: "PlanConclusion",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanManagment_ApplicationUserId",
                table: "PlanManagment",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanMethodicalWork_ApplicationUserId",
                table: "PlanMethodicalWork",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanRemark_ApplicationUserId",
                table: "PlanRemark",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanTrainingJob_ApplicationUserId",
                table: "PlanTrainingJob",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationNMBD_NMBDId",
                table: "PublicationNMBD",
                column: "NMBDId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationNMBD_PublicationId",
                table: "PublicationNMBD",
                column: "PublicationId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationUser_ApplicationUserId",
                table: "PublicationUser",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationUser_ExternalCollaboratorId",
                table: "PublicationUser",
                column: "ExternalCollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationUser_PublicationId",
                table: "PublicationUser",
                column: "PublicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_DepartmentId",
                table: "Schedule",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificPublishing_ApplicationUserId",
                table: "ScientificPublishing",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaySemester");

            migrationBuilder.DropTable(
                name: "DayTeachLoad");

            migrationBuilder.DropTable(
                name: "DDataStorage");

            migrationBuilder.DropTable(
                name: "DepartmentUser");

            migrationBuilder.DropTable(
                name: "EDataStorage");

            migrationBuilder.DropTable(
                name: "ExtramuralSemester");

            migrationBuilder.DropTable(
                name: "ExtramuralTeachLoad");

            migrationBuilder.DropTable(
                name: "IndivPlanFields");

            migrationBuilder.DropTable(
                name: "IndivPlanFieldsValue");

            migrationBuilder.DropTable(
                name: "NDR");

            migrationBuilder.DropTable(
                name: "PlanChange");

            migrationBuilder.DropTable(
                name: "PlanConclusion");

            migrationBuilder.DropTable(
                name: "PlanManagment");

            migrationBuilder.DropTable(
                name: "PlanMethodicalWork");

            migrationBuilder.DropTable(
                name: "PlanRemark");

            migrationBuilder.DropTable(
                name: "PlanTrainingJob");

            migrationBuilder.DropTable(
                name: "PublicationNMBD");

            migrationBuilder.DropTable(
                name: "PublicationUser");

            migrationBuilder.DropTable(
                name: "ScientificPublishing");

            migrationBuilder.DropTable(
                name: "DayEntryLoad");

            migrationBuilder.DropTable(
                name: "Rate");

            migrationBuilder.DropTable(
                name: "ExtramuralEntryLoad");

            migrationBuilder.DropTable(
                name: "IndPlanType");

            migrationBuilder.DropTable(
                name: "NMBD");

            migrationBuilder.DropTable(
                name: "ExternalCollaborator");

            migrationBuilder.DropTable(
                name: "Publication");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Specialize");

            migrationBuilder.DropTable(
                name: "LoadingList");

            migrationBuilder.DropTable(
                name: "Specialty");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Faculty");
        }
    }
}
