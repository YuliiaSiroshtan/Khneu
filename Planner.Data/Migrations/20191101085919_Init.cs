using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Planner.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntryLoadsProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    DateTimeUpload = table.Column<DateTime>(nullable: false),
                    HoursPerRate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryLoadsProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CodeFaculty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FirstSemesters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hours = table.Column<string>(nullable: true),
                    HoursAll = table.Column<string>(nullable: true),
                    Lectures = table.Column<string>(nullable: true),
                    Laboratory = table.Column<string>(nullable: true),
                    Practical = table.Column<string>(nullable: true),
                    IndividualWork = table.Column<string>(nullable: true),
                    CourseWork = table.Column<string>(nullable: true),
                    Exam = table.Column<string>(nullable: true),
                    Credit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstSemesters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecondSemesters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hours = table.Column<string>(nullable: true),
                    HoursAll = table.Column<string>(nullable: true),
                    Lectures = table.Column<string>(nullable: true),
                    Laboratory = table.Column<string>(nullable: true),
                    Practical = table.Column<string>(nullable: true),
                    IndividualWork = table.Column<string>(nullable: true),
                    CourseWork = table.Column<string>(nullable: true),
                    Exam = table.Column<string>(nullable: true),
                    Credit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondSemesters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SelectedDisciplines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedDisciplines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CodeDepartment = table.Column<string>(nullable: true),
                    Classification = table.Column<string>(nullable: true),
                    FacultyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ECTS = table.Column<string>(nullable: true),
                    AmountOfHours = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    WeeksInFirstSemester = table.Column<string>(nullable: true),
                    WeeksInSecondSemester = table.Column<string>(nullable: true),
                    FirstSemesterId = table.Column<int>(nullable: true),
                    SecondSemesterId = table.Column<int>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplines_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplines_FirstSemesters_FirstSemesterId",
                        column: x => x.FirstSemesterId,
                        principalTable: "FirstSemesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplines_SecondSemesters_SecondSemesterId",
                        column: x => x.SecondSemesterId,
                        principalTable: "SecondSemesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ImageSource = table.Column<string>(nullable: true),
                    Rate = table.Column<int>(nullable: false),
                    HoursPerRate = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntryLoads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyId = table.Column<int>(nullable: true),
                    Specialty = table.Column<string>(nullable: true),
                    Specialization = table.Column<string>(nullable: true),
                    Course = table.Column<string>(nullable: true),
                    EducationalDegree = table.Column<string>(nullable: true),
                    AmountOfStudents = table.Column<string>(nullable: true),
                    AmountOfForeignersStudents = table.Column<string>(nullable: true),
                    GroupCode = table.Column<string>(nullable: true),
                    NumberOfGroups = table.Column<string>(nullable: true),
                    RealNumberOfGroups = table.Column<string>(nullable: true),
                    NumberOfSubGroups = table.Column<string>(nullable: true),
                    AmountOfStudentsStreams = table.Column<string>(nullable: true),
                    ConnectingOfStudentStreams = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    DisciplineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryLoads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryLoads_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntryLoads_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndividualPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualPlans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Classification", "CodeDepartment", "FacultyId", "Name" },
                values: new object[,]
                {
                    { 1, "вип", "обк", null, "Обліку і бізнес-консалтингу" },
                    { 29, "заг", "іммк", null, "Іноземних мов та міжкультурної комунікації" },
                    { 28, "заг", "фвс", null, "Фізичного виховання та спорту" },
                    { 27, "заг", "умпіг", null, "Українознавства і мовної підготовки іноземних громадян" },
                    { 26, "вип", "піфп", null, "Педагогіки, іноземної філології та перекладу" },
                    { 25, "вип", "т", null, "Туризму" },
                    { 23, "вип", "уск", null, "Управління соціальними комунікаціями" },
                    { 22, "вип", "етеп", null, "Економічної теорії та економічної політики" },
                    { 21, "вип", "дупаре", null, "Державного управління, публічного адміністрування та регіональної економіки" },
                    { 20, "вип", "пре", null, "Правового регулювання економіки" },
                    { 19, "вип", "епм", null, "Економіки підприємства та менеджменту" },
                    { 18, "вип", "есн", null, "Економіки та соціальних наук" },
                    { 17, "вип", "сеп", null, "Статистики і економічного прогнозування" },
                    { 16, "вип", "кіт", null, "Кібербезпеки та інформаційних технологій" },
                    { 24, "вип", "мемзед", null, "Міжнародної економіки та менеджменту ЗЕД" },
                    { 14, "заг", "ікт", null, "Інформатики та комп’ютерної техніки" },
                    { 13, "вип", "ек", null, "Економічної кібернетики" },
                    { 12, "вип", "ксіт", null, "Комп’ютерних систем і технологій" },
                    { 11, "вип", "іс", null, "Інформаційних систем" },
                    { 10, "вип", "ем", null, "Економіки і маркетингу" },
                    { 9, "вип", "мб", null, "Менеджменту та бізнесу" },
                    { 8, "вип", "мле", null, "Менеджменту, логістики та економіки" },
                    { 7, "вип", "мсо", null, "Митної справи та оподаткування" },
                    { 15, "заг", "птебжд", null, "Природоохоронних технологій, екології та безпеки життєдіяльності" },
                    { 6, "вип", "бсфп", null, "Банківської справи і фінансових послуг" },
                    { 5, "вип", "ф", null, "Фінансів" },
                    { 4, "заг", "фп", null, "Філософії та політології" },
                    { 3, "заг", "вмем", null, "Вищої математики та економіко-математичних методів" },
                    { 2, "вип", "мбеа", null, "Міжнародного бізнесу та економічного аналізу" }
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "CodeFaculty", "Name" },
                values: new object[,]
                {
                    { 7, "піг", "Факультет підготовки іноземних громадян" },
                    { 9, "всі", "Додаткові предмети та майнори" },
                    { 8, "асп", "Аспірвнтура" },
                    { 6, "мев", "Факультет міжнародних економічних відносин" },
                    { 3, "мім", "Фікультет менеджменту і маркетингу" },
                    { 4, "еі", "Факультет економічної інформатики" },
                    { 2, "фф", "Фінансовий факультет" },
                    { 1, "кімб", "Факультет консалтингу і міжнародного бізнесу" },
                    { 5, "еп", "Факультет економіки і права" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Завідувач наукового секотору" },
                    { 2, "Викладач" },
                    { 3, "Голова навчальної частини" },
                    { 4, "Завідувач кафедри" },
                    { 5, "Адміністратор" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DepartmentId", "HoursPerRate", "ImageSource", "Login", "Name", "Password", "Rate", "RoleId" },
                values: new object[,]
                {
                    { 4, null, 0, null, "caf@gmail.com", "Зав кафедры", "T15oO9/ZYIoPbzifVCRgRAZ+MQfamV9vb4nWBde0xts=", 0, null },
                    { 1, null, 0, null, "admin@gmail.com", "Админ", "T15oO9/ZYIoPbzifVCRgRAZ+MQfamV9vb4nWBde0xts=", 0, null },
                    { 2, null, 0, null, "prepod@gmail.com", "Препод", "T15oO9/ZYIoPbzifVCRgRAZ+MQfamV9vb4nWBde0xts=", 0, null },
                    { 3, null, 0, null, "uchebn@gmail.com", "Начальник учебной части", "T15oO9/ZYIoPbzifVCRgRAZ+MQfamV9vb4nWBde0xts=", 0, null },
                    { 5, null, 0, null, "centr@gmail.com", "Зав научного центра", "T15oO9/ZYIoPbzifVCRgRAZ+MQfamV9vb4nWBde0xts=", 0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_FacultyId",
                table: "Departments",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_DepartmentId",
                table: "Disciplines",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_FirstSemesterId",
                table: "Disciplines",
                column: "FirstSemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_SecondSemesterId",
                table: "Disciplines",
                column: "SecondSemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryLoads_DisciplineId",
                table: "EntryLoads",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryLoads_FacultyId",
                table: "EntryLoads",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualPlans_UserId",
                table: "IndividualPlans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntryLoads");

            migrationBuilder.DropTable(
                name: "EntryLoadsProperties");

            migrationBuilder.DropTable(
                name: "IndividualPlans");

            migrationBuilder.DropTable(
                name: "SelectedDisciplines");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FirstSemesters");

            migrationBuilder.DropTable(
                name: "SecondSemesters");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
