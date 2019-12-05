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

            this.CreateMap<UserDto, User>()
                .ForMember(x => x.RoleId, y => y.MapFrom(z => z.Role.Id));
            this.CreateMap<RoleDto, Role>();
            this.CreateMap<RateDto, Rate>();
            this.CreateMap<DepartmentDto, Department>()
                .ForMember(x => x.FacultyId, y => y.MapFrom(z => z.Faculty.Id));
            this.CreateMap<FacultyDto, Faculty>();
            this.CreateMap<EntryLoadsPropertyDto, EntryLoadsProperty>();
            this.CreateMap<UserEntryLoadPropertyDto, UserEntryLoadProperty>();
            this.CreateMap<FullTimeEntryLoadDto, FullTimeEntryLoad>()
                .ForMember(x => x.FullTimeDisciplineId, y => y.MapFrom(z => z.FullTimeDiscipline.Id))
                .ForMember(x => x.FacultyId, y => y.MapFrom(z => z.Faculty.Id));
            this.CreateMap<PartTimeEntryLoadDto, PartTimeEntryLoad>()
                .ForMember(x => x.PartTimeDisciplineId, y => y.MapFrom(z => z.PartTimeDiscipline.Id));
            this.CreateMap<FullTimeDisciplineDto, FullTimeDiscipline>()
                .ForMember(x => x.FirstSemesterId, y => y.MapFrom(z => z.FirstSemester.Id))
                .ForMember(x => x.SecondSemesterId, y => y.MapFrom(z => z.SecondSemester.Id))
                .ForMember(x => x.DepartmentId, y => y.MapFrom(z => z.Department.Id));
            this.CreateMap<PartTimeDisciplineDto, PartTimeDiscipline>()
                .ForMember(x => x.ConstituentSessionId, y => y.MapFrom(z => z.ConstituentSession.Id))
                .ForMember(x => x.ExaminationSessionId, y => y.MapFrom(z => z.ExaminationSession.Id))
                .ForMember(x => x.DepartmentId, y => y.MapFrom(z => z.Department.Id));
            this.CreateMap<FirstSemesterDto, FirstSemester>();
            this.CreateMap<SecondSemesterDto, SecondSemester>();
            this.CreateMap<ConstituentSessionDto, ConstituentSession>();
            this.CreateMap<ExaminationSessionDto, ExaminationSession>();
            this.CreateMap<IndividualPlanDto, IndividualPlan>();
            this.CreateMap<SelectedDisciplineDto, SelectedDiscipline>()
                .ForMember(x => x.DepartmentId, y => y.MapFrom(z => z.Department.Id));
            this.CreateMap<LectureDto, Lecture>()
                .ForMember(x => x.SelectedDisciplineId, y => y.MapFrom(z => z.SelectedDiscipline.Id))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.User.Id));
            this.CreateMap<LaboratoryDto, Laboratory>()
                .ForMember(x => x.SelectedDisciplineId, y => y.MapFrom(z => z.SelectedDiscipline.Id))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.User.Id));
            this.CreateMap<PracticalDto, Practical>()
                .ForMember(x => x.SelectedDisciplineId, y => y.MapFrom(z => z.SelectedDiscipline.Id))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.User.Id));
            this.CreateMap<HoursCalculationOfFirstSemesterDto, HoursCalculationOfFirstSemester>();
            this.CreateMap<HoursCalculationOfSecondSemesterDto, HoursCalculationOfSecondSemester>();

            #endregion

            #region domain to dto

            this.CreateMap<User, UserDto>();
            this.CreateMap<Role, RoleDto>();
            this.CreateMap<Rate, RateDto>();
            this.CreateMap<Department, DepartmentDto>();
            this.CreateMap<Faculty, FacultyDto>();
            this.CreateMap<EntryLoadsProperty, EntryLoadsPropertyDto>();
            this.CreateMap<UserEntryLoadProperty, UserEntryLoadPropertyDto>();
            this.CreateMap<FullTimeEntryLoad, FullTimeEntryLoadDto>();
            this.CreateMap<PartTimeEntryLoad, PartTimeEntryLoadDto>();
            this.CreateMap<FullTimeDiscipline, FullTimeDisciplineDto>();
            this.CreateMap<PartTimeDiscipline, PartTimeDisciplineDto>();
            this.CreateMap<FirstSemester, FirstSemesterDto>();
            this.CreateMap<SecondSemester, SecondSemesterDto>();
            this.CreateMap<ConstituentSession, ConstituentSessionDto>();
            this.CreateMap<ExaminationSession, ExaminationSessionDto>();
            this.CreateMap<IndividualPlan, IndividualPlanDto>();
            this.CreateMap<SelectedDiscipline, SelectedDisciplineDto>();
            this.CreateMap<Lecture, LectureDto>();
            this.CreateMap<Laboratory, LaboratoryDto>();
            this.CreateMap<Practical, PracticalDto>();
            this.CreateMap<HoursCalculationOfFirstSemester, HoursCalculationOfFirstSemesterDto>();
            this.CreateMap<HoursCalculationOfSecondSemester, HoursCalculationOfSecondSemesterDto>();

            #endregion

            #region dto to view model

            this.CreateMap<UserDto, UserViewModel>()
                .ForMember(x => x.RoleName, y => y.MapFrom(z => z.Role.Name))
                .ForMember(x => x.Departments, y => y.MapFrom(z => z.Departments.ToArray()))
                .ForMember(x => x.Rates, y => y.MapFrom(z => z.Rates.ToArray()))
                .ForMember(x => x.SelectedDisciplines, y => y.MapFrom(z => z.SelectedDisciplines.ToArray()));

            this.CreateMap<DepartmentDto, DepartmentViewModel>()
                .ForMember(x => x.FacultyName, y => y.MapFrom(z => z.Faculty.Name));

            this.CreateMap<RateDto, RateViewModel>()
                .ForMember(x => x.DepartmentName, y => y.MapFrom(z => z.Department.Name));

            this.CreateMap<SelectedDisciplineDto, SelectedDisciplinesViewModel>()
                .ForMember(x => x.DepartmentName, y => y.MapFrom(z => z.Department.Name))
                .ForMember(x => x.Lectures, y => y.MapFrom(z => z.Lectures.ToArray()))
                .ForMember(x => x.Laboratories, y => y.MapFrom(z => z.Laboratories.ToArray()))
                .ForMember(x => x.Practicals, y => y.MapFrom(z => z.Practicals.ToArray()));

            this.CreateMap<EntryLoadsPropertyDto, EntryLoadsPropertyViewModel>();
            this.CreateMap<FirstSemesterDto, FirstSemesterViewModel>();
            this.CreateMap<SecondSemesterDto, SecondSemesterViewModel>();
            this.CreateMap<FullTimeDisciplineDto, FullTimeDisciplinesViewModel>();
            this.CreateMap<PartTimeDisciplineDto, PartTimeDisciplineViewModel>();
            this.CreateMap<ConstituentSessionDto, ConstituentSessionViewModel>();
            this.CreateMap<ExaminationSessionDto, ExaminationSessionViewModel>();
            this.CreateMap<LectureDto, LectureViewModel>();
            this.CreateMap<LaboratoryDto, LaboratoryViewModel>();
            this.CreateMap<PracticalDto, PracticalViewModel>();

            #endregion

            #region   view model to dto

            this.CreateMap<UserViewModel, UserDto>()
                .ForMember(x => x.Departments, y => y.MapFrom(z => z.Departments.ToHashSet()))
                .ForMember(x => x.Rates, y => y.MapFrom(z => z.Rates.ToHashSet()))
                .ForMember(x => x.SelectedDisciplines, y => y.MapFrom(z => z.SelectedDisciplines.ToHashSet()));

            this.CreateMap<DepartmentViewModel, DepartmentDto>();

            this.CreateMap<RateViewModel, RateDto>();
            this.CreateMap<SelectedDisciplinesViewModel, SelectedDisciplineDto>()
                .ForMember(x => x.Lectures, y => y.MapFrom(z => z.Lectures.ToHashSet()))
                .ForMember(x => x.Laboratories, y => y.MapFrom(z => z.Laboratories.ToHashSet()))
                .ForMember(x => x.Practicals, y => y.MapFrom(z => z.Practicals.ToHashSet()));
            ;
            this.CreateMap<EntryLoadsPropertyViewModel, EntryLoadsPropertyDto>();
            this.CreateMap<FirstSemesterViewModel, FirstSemesterDto>();
            this.CreateMap<SecondSemesterViewModel, SecondSemesterDto>();
            this.CreateMap<FullTimeDisciplinesViewModel, FullTimeDisciplineDto>();
            this.CreateMap<PartTimeDisciplineViewModel, PartTimeDisciplineDto>();
            this.CreateMap<ConstituentSessionViewModel, ConstituentSessionDto>();
            this.CreateMap<ExaminationSessionViewModel, ExaminationSessionDto>();
            this.CreateMap<LectureViewModel, LectureDto>();
            this.CreateMap<LaboratoryViewModel, LaboratoryDto>();
            this.CreateMap<PracticalViewModel, PracticalDto>();

            #endregion
        }
    }
}