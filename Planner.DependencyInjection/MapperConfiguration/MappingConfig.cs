using AutoMapper;
using Planner.DependencyInjection.ViewModels.IndividualPlan;
using Planner.DependencyInjection.ViewModels.Publication;
using Planner.DependencyInjection.ViewModels.User;
using Planner.Entities.Domain;
using Planner.Entities.Enums;
using Planner.ServiceInterfaces.DTO;
using Planner.ServiceInterfaces.DTO.Distribution;
using Planner.ServiceInterfaces.DTO.IndividualPlan;
using Planner.ServiceInterfaces.DTO.Publication;
using System;
using System.Linq;

namespace Planner.DependencyInjection.MapperConfiguration
{
    internal class MappingConfig : Profile
    {
        public MappingConfig()
        {
            #region dto to domain
            CreateMap<UserDTO, ApplicationUser>()
                .ForMember(s => s.Email, x => x.MapFrom(z => z.Email))
                .ForMember(s => s.UserName, x => x.MapFrom(z => z.Email))
                .ForMember(s => s.DegreeId , x => x.MapFrom(z => z.Degree))
                .ForMember(s => s.PositionId , x => x.MapFrom(z => z.Position))
                .ForMember(s => s.AcademicTitleId , x => x.MapFrom(z => z.AcademicTitle));

            CreateMap<PublicationAddEditDTO, Publication>();
            #endregion

            #region domail to dto
            CreateMap<ApplicationUser, UserDTO>()
                 .ForMember(s => s.AcademicTitle, x => x.MapFrom(z => z.AcademicTitleId))
                 .ForMember(s => s.Degree, x => x.MapFrom(z => z.DegreeId))
                 .ForMember(s => s.Position, x => x.MapFrom(z => z.PositionId))
                 .ForMember(s => s.RoleName, x => x.MapFrom(z => z.Role.Name))
                 .ForMember(s => s.AcademicTitleViewMode, x => x.MapFrom(z => z.AcademicTitleId.HasValue ? z.AcademicTitleId.Value.GetDescription() : null))
                 .ForMember(s => s.DegreeViewMode, x => x.MapFrom(z => z.DegreeId.HasValue ? z.DegreeId.Value.GetDescription() : null))
                 .ForMember(s => s.PositionViewMode, x => x.MapFrom(z => z.PositionId.HasValue ? z.PositionId.Value.GetDescription() : null));

            CreateMap<ApplicationUser, UserListItemDTO>()
                .ForMember(s => s.FullName, x => x.MapFrom(z => $"{z.LastName} {z.FirstName} {z.ThirdName}"));
            CreateMap<Publication, PublicationDTO>()
                .ForMember(s => s.CollaboratorsName, x => x.MapFrom(z => String.Join(',', z.PublicationUsers.Select(a => String.Format("{0} {1} {2}", a.User.LastName, a.User.FirstName, a.User.ThirdName)))));

            CreateMap<PlanTrainingJob, TrainingJobDTO>();

            CreateMap<DayEntryLoad, DayEntryDTO>()
             .ForMember(s => s.DayEntryId, x => x.MapFrom(z => z.DayEntryLoadId))
             .ForMember(s => s.Faculty, x => x.MapFrom(z => z.FacultyName))
             .ForMember(s => s.Faculty, x => x.MapFrom(z => z.FacultyName))
             .ForMember(s => s.Specialty, x => x.MapFrom(z => z.Specialty.Code))
             .ForMember(s => s.Specialization, x => x.MapFrom(z => z.Specialize.Cipher))
             .ForMember(s => s.Course, x => x.MapFrom(z => z.Course.Literal))
             .ForMember(s => s.StudentsCount, x => x.MapFrom(z => z.QuantityOfStudents))
             .ForMember(s => s.ForeignersCount, x => x.MapFrom(z => z.QuantityOfForeigners))
             .ForMember(s => s.GroupsCipher, x => x.MapFrom(z => z.CipherOfGroups))
             .ForMember(s => s.QuantityOfGroupsA, x => x.MapFrom(z => z.QuantityOfGroupsCritOne))
             .ForMember(s => s.RealQuantityOfGroups, x => x.MapFrom(z => z.RealQuantityOfGroups))
             .ForMember(s => s.QuantityOfGroupsB, x => x.MapFrom(z => z.QuantityOfGroupsCritTwo))
             .ForMember(s => s.QuantityOfThreads, x => x.MapFrom(z => z.QuantityOfThreads))
             .ForMember(s => s.Notes, x => x.MapFrom(z => z.Note))
             .ForMember(s => s.Subject, x => x.MapFrom(z => z.Subject.Name))
             .ForMember(s => s.QuantityOfCredits, x => x.MapFrom(z => z.CountOfCredits))
             .ForMember(s => s.Hours, x => x.MapFrom(z => z.CountOfHours))
             .ForMember(s => s.QuantityOfWeeksFs, x => x.MapFrom(z => z.FS_CountOfWeeks))
             .ForMember(s => s.QuantityOfWeeksSs, x => x.MapFrom(z => z.SS_CountOfWeeks))
             .ForMember(s => s.DeS, x => new DayEntrySemesterDTO()
             {
                
                 //TotalHours =  x.MapFrom(c => c.DaySemesters.Count > 0 && c.DaySemesters.FirstOrDefault().Semester == (byte)SemesterType.First ? c.F_TotalHour : c.S_TotalHour),
                 
                 //x.NewIgnore(z => z.DaySemesters.First().DaySemesterId)
             })
             .ForMember(s => s.DaySemesterId, x => x.MapFrom(z => z.DaySemesters.First().DaySemesterId))
             .ForMember(s => s.Dd, x => new DayDistributionDTO()
             {
                 //Semester = x.MapFrom(z => z.DaySemesters.FirstOrDefault() != null?  z.DaySemesters.FirstOrDefault().Semester : 0),
                 //Lecture = ds.Lecture,
                 //Practice = ds.Practice,
                 //Lab = ds.Lab,
                 //ConsultInSemester = ds.ConsultInSemester,
                 //ConsultForExam = ds.ConsultForExam,
                 //VerifyingOfTests = ds.VerifyingOfTests,
                 //KR_KP = ds.KR_KP,
                 //ControlEvaluation = ds.ControlEvaluation,
                 //ControlExam = ds.ControlExam,
                 //PracticePreparation = ds.PracticePreparation,
                 //Dek = ds.Dek,
                 //StateExam = ds.StateExam,
                 //ManagedDiploma = ds.ManagedDiploma,
                 //Other = ds.Other,
                 //Total = ds.Total,
                 //Active = ds.Active,
                 //EnglishBonus = ds.EnglishBonus
             })
              .ForMember(s => s.CoeficientFs, x => x.MapFrom(z => z.FSemCoefficient))
               .ForMember(s => s.CoeficientSs, x => x.MapFrom(z => z.SSemCoefficient))
                .ForMember(s => s.Projects, x => x.MapFrom(z => z.KR_KP_DR))
                 .ForMember(s => s.Practices, x => x.MapFrom(z => z.Practice))
                  .ForMember(s => s.QuantityOfMembers, x => x.MapFrom(z => z.QuantityOfDek));
            #endregion

            #region dto to view model
            CreateMap<UserDTO, UserInfoViewModel>();
            CreateMap<UserListItemDTO, UserListItemViewModel>();

            CreateMap<TrainingJobDTO, TrainingJobViewModel>();
            
            //.ForMember(s => s.UserName, x => x.MapFrom(z => z.Email));
            #endregion

            #region   view model to dto
            CreateMap<UserInfoViewModel,UserDTO>();
            CreateMap<PublicationAddEditViewModel, PublicationAddEditDTO>();
            //.ForMember(s => s.UserName, x => x.MapFrom(z => z.Email));
            #endregion
        }
    }
}
