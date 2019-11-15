using AutoMapper;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.Entities.Domain.AppSelectedDiscipline;
using Planner.Entities.Domain.AppUser;
using Planner.Entities.Domain.UniversityUnits;
using Planner.Entities.DTO.AppEntryLoadDto;
using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using Planner.Entities.DTO.AppSelectedDisciplineDto;
using Planner.Entities.DTO.AppUserDto;
using Planner.Entities.DTO.UniversityUnits;
using Planner.PresentationLayer.ViewModels;
using System.Linq;

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
                .ForMember(x => x.FullTimeDisciplineId, y => y.MapFrom(z => z.FullTimeDiscipline.Id))
                .ForMember(x => x.FacultyId, y => y.MapFrom(z => z.Faculty.Id));
            CreateMap<PartTimeEntryLoadDto, PartTimeEntryLoad>()
                .ForMember(x => x.PartTimeDisciplineId, y => y.MapFrom(z => z.PartTimeDiscipline.Id));
            CreateMap<FullTimeDisciplineDto, FullTimeDiscipline>()
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
            CreateMap<LectureDto, Lecture>()
                .ForMember(x => x.SelectedDisciplineId, y => y.MapFrom(z => z.SelectedDiscipline.Id))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.User.Id));
            CreateMap<LaboratoryDto, Laboratory>()
                .ForMember(x => x.SelectedDisciplineId, y => y.MapFrom(z => z.SelectedDiscipline.Id))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.User.Id));
            CreateMap<PracticalDto, Practical>()
                .ForMember(x => x.SelectedDisciplineId, y => y.MapFrom(z => z.SelectedDiscipline.Id))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.User.Id));

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
            CreateMap<FullTimeDiscipline, FullTimeDisciplineDto>();
            CreateMap<PartTimeDiscipline, PartTimeDisciplineDto>();
            CreateMap<FirstSemester, FirstSemesterDto>();
            CreateMap<SecondSemester, SecondSemesterDto>();
            CreateMap<ConstituentSession, ConstituentSessionDto>();
            CreateMap<ExaminationSession, ExaminationSessionDto>();
            CreateMap<IndividualPlan, IndividualPlanDto>();
            CreateMap<SelectedDiscipline, SelectedDisciplineDto>();
            CreateMap<Lecture, LectureDto>();
            CreateMap<Laboratory, LaboratoryDto>();
            CreateMap<Practical, PracticalDto>();

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
                .ForMember(x => x.DepartmentName, y => y.MapFrom(z => z.Department.Name))
                .ForMember(x => x.Lectures, y => y.MapFrom(z => z.Lectures.ToArray()))
                .ForMember(x => x.Laboratories, y => y.MapFrom(z => z.Laboratories.ToArray()))
                .ForMember(x => x.Practicals, y => y.MapFrom(z => z.Practicals.ToArray()));

            CreateMap<EntryLoadsPropertyDto, EntryLoadsPropertyViewModel>();
            CreateMap<FirstSemesterDto, FirstSemesterViewModel>();
            CreateMap<SecondSemesterDto, SecondSemesterViewModel>();
            CreateMap<FullTimeDisciplineDto, FullTimeDisciplinesViewModel>();
            CreateMap<PartTimeDisciplineDto, PartTimeDisciplineViewModel>();
            CreateMap<ConstituentSessionDto, ConstituentSessionViewModel>();
            CreateMap<ExaminationSessionDto, ExaminationSessionViewModel>();
            CreateMap<LectureDto, LectureViewModel>();
            CreateMap<LaboratoryDto, LaboratoryViewModel>();
            CreateMap<PracticalDto, PracticalViewModel>();

            #endregion

            #region   view model to dto

            CreateMap<UserViewModel, UserDto>()
                .ForMember(x => x.Departments, y => y.MapFrom(z => z.Departments.ToHashSet()))
                .ForMember(x => x.Rates, y => y.MapFrom(z => z.Rates.ToHashSet()))
                .ForMember(x => x.SelectedDisciplines, y => y.MapFrom(z => z.SelectedDisciplines.ToHashSet()));

            CreateMap<DepartmentViewModel, DepartmentDto>();

            CreateMap<RateViewModel, RateDto>();
            CreateMap<SelectedDisciplinesViewModel, SelectedDisciplineDto>()
                .ForMember(x => x.Lectures, y => y.MapFrom(z => z.Lectures.ToHashSet()))
                .ForMember(x => x.Laboratories, y => y.MapFrom(z => z.Laboratories.ToHashSet()))
                .ForMember(x => x.Practicals, y => y.MapFrom(z => z.Practicals.ToHashSet())); ;
            CreateMap<EntryLoadsPropertyViewModel, EntryLoadsPropertyDto>();
            CreateMap<FirstSemesterViewModel, FirstSemesterDto>();
            CreateMap<SecondSemesterViewModel, SecondSemesterDto>();
            CreateMap<FullTimeDisciplinesViewModel, FullTimeDisciplineDto>();
            CreateMap<PartTimeDisciplineViewModel, PartTimeDisciplineDto>();
            CreateMap<ConstituentSessionViewModel, ConstituentSessionDto>();
            CreateMap<ExaminationSessionViewModel, ExaminationSessionDto>();
            CreateMap<LectureViewModel, LectureDto>();
            CreateMap<LaboratoryViewModel, LaboratoryDto>();
            CreateMap<PracticalViewModel, PracticalDto>();

            #endregion
        }
    }
}
