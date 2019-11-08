using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Entities.Domain;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.Domain.AppEntryLoad.FullTime;

namespace Planner.Data.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(new Department
            {
                Id = 1,
                Name = "Обліку і бізнес-консалтингу",
                CodeDepartment = "обк",
                Classification = "вип"
            }, new Department
            {
                Id = 2,
                Name = "Міжнародного бізнесу та економічного аналізу",
                CodeDepartment = "мбеа",
                Classification = "вип"
            }, new Department
            {
                Id =3,
                Name = "Вищої математики та економіко-математичних методів",
                CodeDepartment = "вмем",
                Classification = "заг"
            }, new Department
            {
                Id = 4,
                Name = "Філософії та політології",
                CodeDepartment = "фп",
                Classification = "заг"
            }, new Department
            {
                Id = 5,
                Name = "Фінансів",
                CodeDepartment = "ф",
                Classification = "вип"
            }, new Department
            {
                Id = 6,
                Name = "Банківської справи і фінансових послуг",
                CodeDepartment = "бсфп",
                Classification = "вип"
            }, new Department
            {
                Id = 7,
                Name = "Митної справи та оподаткування",
                CodeDepartment = "мсо",
                Classification = "вип"
            }, new Department
            {
                Id = 8,
                Name = "Менеджменту, логістики та економіки",
                CodeDepartment = "мле",
                Classification = "вип"
            }, new Department
            {
                Id = 9,
                Name = "Менеджменту та бізнесу",
                CodeDepartment = "мб",
                Classification = "вип"
            }, new Department
            {
                Id = 10,
                Name = "Економіки і маркетингу",
                CodeDepartment = "ем",
                Classification = "вип"
            }, new Department
            {
                Id = 11,
                Name = "Інформаційних систем",
                CodeDepartment = "іс",
                Classification = "вип"
            }, new Department
            {
                Id = 12,
                Name = "Комп’ютерних систем і технологій",
                CodeDepartment = "ксіт",
                Classification = "вип"
            }, new Department
            {
                Id = 13,
                Name = "Економічної кібернетики",
                CodeDepartment = "ек",
                Classification = "вип"
            }, new Department
            {
                Id = 14,
                Name = "Інформатики та комп’ютерної техніки",
                CodeDepartment = "ікт",
                Classification = "заг"
            }, new Department
            {
                Id = 15,
                Name = "Природоохоронних технологій, екології та безпеки життєдіяльності",
                CodeDepartment = "птебжд",
                Classification = "заг"
            }, new Department
            {
                Id = 16,
                Name = "Кібербезпеки та інформаційних технологій",
                CodeDepartment = "кіт",
                Classification = "вип"
            }, new Department
            {
                Id = 17,
                Name = "Статистики і економічного прогнозування",
                CodeDepartment = "сеп",
                Classification = "вип"
            }, new Department
            {
                Id = 18,
                Name = "Економіки та соціальних наук",
                CodeDepartment = "есн",
                Classification = "вип"
            }, new Department
            {
                Id = 19,
                Name = "Економіки підприємства та менеджменту",
                CodeDepartment = "епм",
                Classification = "вип"
            }, new Department
            {
                Id = 20,
                Name = "Правового регулювання економіки",
                CodeDepartment = "пре",
                Classification = "вип"
            }, new Department
            {
                Id = 21,
                Name = "Державного управління, публічного адміністрування та регіональної економіки",
                CodeDepartment = "дупаре",
                Classification = "вип"
            }, new Department
            {
                Id = 22,
                Name = "Економічної теорії та економічної політики",
                CodeDepartment = "етеп",
                Classification = "вип"
            }, new Department
            {
                Id = 23,
                Name = "Управління соціальними комунікаціями",
                CodeDepartment = "уск",
                Classification = "вип"
            }, new Department
            {
                Id = 24,
                Name = "Міжнародної економіки та менеджменту ЗЕД",
                CodeDepartment = "мемзед",
                Classification = "вип"
            }, new Department
            {
                Id = 25,
                Name = "Туризму",
                CodeDepartment = "т",
                Classification = "вип"
            }, new Department
            {
                Id = 26,
                Name = "Педагогіки, іноземної філології та перекладу",
                CodeDepartment = "піфп",
                Classification = "вип"
            }, new Department
            {
                Id = 27,
                Name = "Українознавства і мовної підготовки іноземних громадян",
                CodeDepartment = "умпіг",
                Classification = "заг"
            }, new Department
            {
                Id = 28,
                Name = "Фізичного виховання та спорту",
                CodeDepartment = "фвс",
                Classification = "заг"
            }, new Department
            {
                Id = 29,
                Name = "Іноземних мов та міжкультурної комунікації",
                CodeDepartment = "іммк",
                Classification = "заг"
            });
        }
    }
}
