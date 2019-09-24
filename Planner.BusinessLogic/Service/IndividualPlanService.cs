using AutoMapper;
using Planner.Entities.Domain;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.DTO.IndividualPlan;
using Planner.ServiceInterfaces.Interfaces;
using System.Collections.Generic;

namespace Planner.BusinessLogic.Service
{
    public class IndividualPlanService : IIndividualPlanService
    {
        private IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private ISecurityService _securityService;

        public IndividualPlanService(IUnitOfWork uow, IMapper mapper, ISecurityService securityService)
        {
            _uow = uow;
            _mapper = mapper;
            _securityService = securityService;
        }

        public bool UpdateTrainingJob(TrainingJobDTO trainingJobDTO)
        {
            PlanTrainingJob trainingJob = _mapper.Map<PlanTrainingJob>(trainingJobDTO);
            _uow.PlanTrainingRepository.UpdateTrainingJob(trainingJob);

            return _uow.SaveChanges() >= 0;
        }

        public IEnumerable<TrainingJobDTO> GetTrainingJob(string userName)
        {
            IEnumerable<PlanTrainingJob> trainingJob = _uow.PlanTrainingRepository.GetTrainingJob(userName);
            return _mapper.Map<IEnumerable<TrainingJobDTO>>(trainingJob);
        }

        public bool UpdateIndivPlanFieldValue(IndivPlanFieldValueDTO indivPlanFieldValueDTO)
        {
            IndivPlanFieldsValue indivPlanFieldsValue = _mapper.Map<IndivPlanFieldsValue>(indivPlanFieldValueDTO);
            _uow.IndivPlanFieldsValueRepository.UpdateIndivPlanFieldValue(indivPlanFieldsValue);

            return _uow.SaveChanges() >= 0;
        }

        public IEnumerable<IndivPlanFieldValueDTO> GetIndivPlanFieldValue(string userName)
        {
            IEnumerable<IndivPlanFieldsValue> indivPlanFieldsValue = _uow.IndivPlanFieldsValueRepository.GetIndivPlanFieldValue(userName);
            return _mapper.Map<IEnumerable<IndivPlanFieldValueDTO>>(indivPlanFieldsValue);
        }

        public IEnumerable<IndivPlanFieldDTO> GetIndivPlanField(string indPlanTypeId)
        {
            IEnumerable<IndivPlanFields> indivPlanFields = _uow.IndivPlanFieldsRepository.GetIndivPlanField(indPlanTypeId);
            return _mapper.Map<IEnumerable<IndivPlanFieldDTO>>(indivPlanFields);
        }
    }
}
