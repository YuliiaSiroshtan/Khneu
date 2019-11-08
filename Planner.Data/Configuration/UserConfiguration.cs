using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Entities.Domain.AppUser;

namespace Planner.Data.Configuration
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User
            {
                Id = 1,
                Name = "Админ",
                Login = "admin@gmail.com",
                Password = "T15oO9/ZYIoPbzifVCRgRAZ+MQfamV9vb4nWBde0xts="
            }, new User
            {
                Id = 2,
                Name = "Препод",
                Login = "prepod@gmail.com",
                Password = "T15oO9/ZYIoPbzifVCRgRAZ+MQfamV9vb4nWBde0xts="
            }, new User
            {
                Id = 3,
                Name = "Начальник учебной части",
                Login = "uchebn@gmail.com",
                Password = "T15oO9/ZYIoPbzifVCRgRAZ+MQfamV9vb4nWBde0xts="
            }, new User
            {
                Id = 4,
                Name = "Зав кафедры",
                Login = "caf@gmail.com",
                Password = "T15oO9/ZYIoPbzifVCRgRAZ+MQfamV9vb4nWBde0xts="
            }, new User
            {
                Id = 5,
                Name = "Зав научного центра",
                Login = "centr@gmail.com",
                Password = "T15oO9/ZYIoPbzifVCRgRAZ+MQfamV9vb4nWBde0xts="
            });
        }
    }
}
