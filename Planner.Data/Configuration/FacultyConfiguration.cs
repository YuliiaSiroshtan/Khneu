using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.Domain.AppEntryLoad.FullTime;

namespace Planner.Data.Configuration
{
    public class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder.HasData(new Faculty
            {
                Id = 1,
                Name = "Факультет консалтингу і міжнародного бізнесу",
                CodeFaculty = "кімб"
            }, new Faculty
            {
                Id = 2,
                Name = "Фінансовий факультет",
                CodeFaculty = "фф"
            }, new Faculty
            {
                Id = 3,
                Name = "Фікультет менеджменту і маркетингу",
                CodeFaculty = "мім"
            }, new Faculty
            {
                Id = 4,
                Name = "Факультет економічної інформатики",
                CodeFaculty = "еі"
            }, new Faculty
            {
                Id = 5,
                Name = "Факультет економіки і права",
                CodeFaculty = "еп"
            }, new Faculty
            {
                Id = 6,
                Name = "Факультет міжнародних економічних відносин",
                CodeFaculty = "мев"
            }, new Faculty
            {
                Id = 7,
                Name = "Факультет підготовки іноземних громадян",
                CodeFaculty = "піг"
            }, new Faculty
            {
                Id = 8,
                Name = "Аспірвнтура",
                CodeFaculty = "асп"
            }, new Faculty
            {
                Id = 9,
                Name = "Додаткові предмети та майнори",
                CodeFaculty = "всі"
            });
        }
    }
}
