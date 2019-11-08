using System.Linq;
using AutoMapper;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.Entities.Domain.AppUser;
using Planner.Entities.DTO;
using Planner.Entities.DTO.AppUserDto;
using Planner.PresentationLayer.ViewModels;

namespace Planner.DependencyInjection.MapperConfiguration
{
    internal class MappingConfig : Profile
    {
        public MappingConfig()
        {
            #region dto to domain

            CreateMap<UserDto, User>()
                .ForMember(x => x.RoleId, y => y.MapFrom(z => z.Role.Id));
            CreateMap<RoleDto, Role>();
            CreateMap<RateDto, Rate>();
            CreateMap<DepartmentDto, Department>()
                .ForMember(x => x.FacultyId, y => y.MapFrom(z => z.Faculty.Id));
            CreateMap<FacultyDto, Faculty>();
            CreateMap<EntryLoadsPropertyDto, EntryLoadsProperty>();
            CreateMap<FullTimeEntryLoadDto, FullTimeEntryLoad>()
                .ForMember(x => x.DisciplineId, y => y.MapFrom(z => z.Discipline.Id))
                .ForMember(x => x.FacultyId, y => y.MapFrom(z => z.Faculty.Id));
            CreateMap<PartTimeEntryLoadDto, PartTimeEntryLoad>()
                .ForMember(x => x.PartTimeDisciplineId, y => y.MapFrom(z => z.PartTimeDiscipline.Id));
            CreateMap<DisciplineDto, Discipline>()
                .ForMember(x => x.FirstSemesterId, y => y.MapFrom(z => z.FirstSemester.Id))
                .ForMember(x => x.SecondSemesterId, y => y.MapFrom(z => z.SecondSemester.Id))
                .ForMember(x => x.DepartmentId, y => y.MapFrom(z => z.Department.Id));
            CreateMap<PartTimeDisciplineDto, PartTimeDiscipline>()
                .ForMember(x => x.ConstituentSessionId, y => y.MapFrom(z => z.ConstituentSession.Id))
                .ForMember(x => x.ExaminationSessionId, y => y.MapFrom(z => z.ExaminationSession.Id))
                .ForMember(x => x.DepartmentId, y => y.MapFrom(z => z.Department.Id));
            CreateMap<FirstSemesterDto, FirstSemester>();
            CreateMap<SecondSemesterDto, SecondSemester>();
            CreateMap<ConstituentSessionDto, ConstituentSession>();
            CreateMap<ExaminationSessionDto, ExaminationSession>();
            CreateMap<IndividualPlanDto, IndividualPlan>();
            CreateMap<SelectedDisciplineDto, SelectedDiscipline>()
                .ForMember(x => x.DepartmentId, y => y.MapFrom(z => z.Department.Id));

            #endregion

            #region domain to dto

            CreateMap<User, UserDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<Rate, RateDto>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<Faculty, FacultyDto>();
            CreateMap<EntryLoadsProperty, EntryLoadsPropertyDto>();
            CreateMap<FullTimeEntryLoad, FullTimeEntryLoadDto>();
            CreateMap<PartTimeEntryLoad, PartTimeEntryLoadDto>();
            CreateMap<Discipline, DisciplineDto>();
            CreateMap<PartTimeDiscipline, PartTimeDisciplineDto>();
            CreateMap<FirstSemester, FirstSemesterDto>();
            CreateMap<SecondSemester, SecondSemesterDto>();
            CreateMap<ConstituentSession, ConstituentSessionDto>();
            CreateMap<ExaminationSession, ExaminationSessionDto>();
            CreateMap<IndividualPlan, IndividualPlanDto>();
            CreateMap<SelectedDiscipline, SelectedDisciplineDto>();

            #endregion

            #region dto to view model

            CreateMap<UserDto, UserViewModel>()
                .ForMember(x => x.RoleName, y => y.MapFrom(z => z.Role.Name))
                .ForMember(x => x.Departments, y => y.MapFrom(z => z.Departments.ToArray()))
                .ForMember(x => x.Rates, y => y.MapFrom(z => z.Rates.ToArray()))
                .ForMember(x => x.SelectedDisciplines, y => y.MapFrom(z => z.SelectedDisciplines.ToArray()));

            CreateMap<DepartmentDto, DepartmentViewModel>()
                .ForMember(x => x.FacultyName, y => y.MapFrom(z => z.Faculty.Name));

            CreateMap<RateDto, RateViewModel>()
                .ForMember(x => x.DepartmentName, y => y.MapFrom(z => z.Department.Name));

            CreateMap<SelectedDisciplineDto, SelectedDisciplinesViewModel>()
                .ForMember(x => x.DepartmentName, y => y.MapFrom(z => z.Department.Name));

            CreateMap<EntryLoadsPropertyDto, EntryLoadsPropertyViewModel>();

            #endregion

            #region   view model to dto

            CreateMap<UserViewModel, UserDto>()
                //.ForMember(x => x.Role.Name, y => y.MapFrom(z => z.RoleName))
                .ForMember(x => x.Departments, y => y.MapFrom(z => z.Departments.ToHashSet()))
                .ForMember(x => x.Rates, y => y.MapFrom(z => z.Rates.ToHashSet()))
                .ForMember(x => x.SelectedDisciplines, y => y.MapFrom(z => z.SelectedDisciplines.ToHashSet()));

            CreateMap<DepartmentViewModel, DepartmentDto>()
                /*.ForMember(x => x.Faculty.Name, y => y.MapFrom(z => z.FacultyName))*/;

            CreateMap<RateViewModel, RateDto>();

            CreateMap<SelectedDisciplinesViewModel, SelectedDisciplineDto>();

            CreateMap<EntryLoadsPropertyViewModel, EntryLoadsPropertyDto>();

            #endregion
        }
    }
}
