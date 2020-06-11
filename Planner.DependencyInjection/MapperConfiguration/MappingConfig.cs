using AutoMapper;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.Entities.Domain.AppNdr;
using Planner.Entities.Domain.AppPublication;
using Planner.Entities.Domain.AppSelectedDiscipline;
using Planner.Entities.Domain.AppUser;
using Planner.Entities.Domain.UniversityUnits;
using Planner.Entities.DTO.AppEntryLoadDto;
using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using Planner.Entities.DTO.AppNdrDto;
using Planner.Entities.DTO.AppPublicationDto;
using Planner.Entities.DTO.AppSelectedDisciplineDto;
using Planner.Entities.DTO.AppUserDto;
using Planner.Entities.DTO.UniversityUnits;
using System.Linq;

namespace Planner.DependencyInjection.MapperConfiguration
{
    internal class MappingConfig : Profile
    {
        public MappingConfig()
        {
            this.CreateMap<UserDto, User>()
                .ForPath(x => x.Role.Name, y => y.MapFrom(z => z.RoleName));
            this.CreateMap<DepartmentDto, Department>()
                .ForPath(x => x.Faculty.Name, y => y.MapFrom(z => z.FacultyName));
            this.CreateMap<FullTimeDisciplineDto, FullTimeDiscipline>()
                .ForPath(x => x.FirstSemesterId, y => y.MapFrom(z => z.FirstSemester.Id))
                .ForPath(x => x.SecondSemesterId, y => y.MapFrom(z => z.SecondSemester.Id));
            this.CreateMap<PartTimeDisciplineDto, PartTimeDiscipline>()
                .ForPath(x => x.ConstituentSessionId, y => y.MapFrom(z => z.ConstituentSession.Id))
                .ForPath(x => x.ExaminationSessionId, y => y.MapFrom(z => z.ExaminationSession.Id))
                .ForPath(x => x.DepartmentId, y => y.MapFrom(z => z.Department.Id));
            this.CreateMap<SelectedDisciplineDto, SelectedDiscipline>()
                .ForMember(x => x.Department, y => y.Ignore());
            this.CreateMap<LectureDto, Lecture>()
                .ForMember(x => x.SelectedDisciplineId, y => y.MapFrom(z => z.SelectedDisciplineId))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId));
            this.CreateMap<LaboratoryDto, Laboratory>()
                .ForMember(x => x.SelectedDisciplineId, y => y.MapFrom(z => z.SelectedDisciplineId))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId));
            this.CreateMap<PracticalDto, Practical>()
                .ForMember(x => x.SelectedDisciplineId, y => y.MapFrom(z => z.SelectedDisciplineId))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId));

            this.CreateMap<FirstSemesterDto, FirstSemester>().ReverseMap();
            this.CreateMap<SecondSemesterDto, SecondSemester>().ReverseMap();
            this.CreateMap<ConstituentSessionDto, ConstituentSession>().ReverseMap();
            this.CreateMap<ExaminationSessionDto, ExaminationSession>().ReverseMap();
            this.CreateMap<RoleDto, Role>().ReverseMap();
            this.CreateMap<RateDto, Rate>().ReverseMap();
            this.CreateMap<FacultyDto, Faculty>().ReverseMap();
            this.CreateMap<EntryLoadsPropertyDto, EntryLoadsProperty>().ReverseMap();
            this.CreateMap<UserEntryLoadPropertyDto, UserEntryLoadProperty>().ReverseMap();
            this.CreateMap<HoursCalculationOfFirstSemesterDto, HoursCalculationOfFirstSemester>().ReverseMap();
            this.CreateMap<HoursCalculationOfSecondSemesterDto, HoursCalculationOfSecondSemester>().ReverseMap();
            this.CreateMap<FullTimeEntryLoadDto, FullTimeEntryLoad>().ReverseMap();
            this.CreateMap<PartTimeDisciplineDto, PartTimeDiscipline>().ReverseMap();

            this.CreateMap<User, UserDto>();
            this.CreateMap<Department, DepartmentDto>();
            this.CreateMap<FullTimeDiscipline, FullTimeDisciplineDto>();
            this.CreateMap<PartTimeDiscipline, PartTimeDisciplineDto>();
            this.CreateMap<SelectedDiscipline, SelectedDisciplineDto>();
            this.CreateMap<Lecture, LectureDto>();
            this.CreateMap<Laboratory, LaboratoryDto>();
            this.CreateMap<Practical, PracticalDto>();


            this.CreateMap<Publication, PublicationDTO>()
                .ForMember(s => s.CollaboratorsName, 
                            x => x.MapFrom(z => string.Join(',', z.PublicationUsers.Select(a => string.Format("{0}", a.User.Name)))));

            this.CreateMap<NMBD, NmbdDTO>();
            this.CreateMap<NDR, NdrListDTO>();
            this.CreateMap<NDR, NdrDTO>();
            this.CreateMap<NdrDTO, NDR>();


        }
    }
}