using AutoMapper;
using Planner.BusinessLogic.Services.Base;
using Planner.Entities.Domain.AppSelectedDiscipline;
using Planner.Entities.DTO.AppSelectedDisciplineDto;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces.AppSelectedDiscipline;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Services.AppSelectedDiscipline
{
    public class LectureService : BaseService, ILectureService
    {
        public LectureService(IRepositoryScope repositoryScope, IMapper mapper) : base(repositoryScope, mapper) { }

        public async Task<int> InsertLecture(LectureDto lectureDto)
        {
            var lecture = this.Mapper.Map<Lecture>(lectureDto);

            return await this.RepositoryScope.LectureRepository.InsertLecture(lecture);
        }
    }
}