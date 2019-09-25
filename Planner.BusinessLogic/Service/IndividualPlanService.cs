using AutoMapper;
using Planner.Entities.Domain;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.DTO.IndividualPlan;
using Planner.ServiceInterfaces.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service
{
    public class IndividualPlanService : IIndividualPlanService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ISecurityService _securityService;

        public IndividualPlanService(IUnitOfWork uow, IMapper mapper, ISecurityService securityService)
        {
            _uow = uow;
            _mapper = mapper;
            _securityService = securityService;
        }

        public async Task<bool> UpdateTrainingJob(TrainingJobDTO trainingJobDTO)
        {
            var trainingJob = _mapper.Map<PlanTrainingJob>(trainingJobDTO);
            _uow.PlanTrainingRepository.UpdateTrainingJob(trainingJob);

            return await _uow.SaveChanges() >= 0;
        }

        public IEnumerable<TrainingJobDTO> GetTrainingJob(string userName)
        {
            var trainingJob = _uow.PlanTrainingRepository.GetTrainingJob(userName);

            return _mapper.Map<IEnumerable<TrainingJobDTO>>(trainingJob);
        }

        public async Task<bool> UpdateIndivPlanFieldValue(IndivPlanFieldValueDTO indivPlanFieldValueDTO)
        {
            var indivPlanFieldsValue = _mapper.Map<IndivPlanFieldsValue>(indivPlanFieldValueDTO);
            _uow.IndividualPlanFieldsValueRepository.UpdateIndividualPlanFieldValue(indivPlanFieldsValue);

            return await _uow.SaveChanges() >= 0;
        }

        public IEnumerable<IndivPlanFieldValueDTO> GetIndivPlanFieldValue(string userName)
        {
            var indivPlanFieldsValue = _uow.IndividualPlanFieldsValueRepository.GetIndividualPlanFieldValue(userName);

            return _mapper.Map<IEnumerable<IndivPlanFieldValueDTO>>(indivPlanFieldsValue);
        }

        public IEnumerable<IndivPlanFieldDTO> GetIndivPlanField(string indPlanTypeId)
        {
            var indivPlanFields = _uow.IndividualPlanFieldsRepository.GetIndivPlanField(indPlanTypeId);

            return _mapper.Map<IEnumerable<IndivPlanFieldDTO>>(indivPlanFields);
        }
    }
}
