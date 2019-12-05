using AutoMapper;
using Planner.BusinessLogic.Service.Base;
using Planner.Entities.Domain.AppSelectedDiscipline;
using Planner.Entities.DTO.AppSelectedDisciplineDto;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppSelectedDiscipline;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppSelectedDiscipline
{
    public class LectureService : BaseService, ILectureService
    {
        public LectureService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public async Task<int> InsertLecture(LectureDto lectureDto)
        {
            var lecture = this.Mapper.Map<Lecture>(lectureDto);

            return await this.Uow.LectureRepository.InsertLecture(lecture);
        }
    }
}