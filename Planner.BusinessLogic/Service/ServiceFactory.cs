using Planner.ServiceInterfaces.Interfaces;

namespace Planner.BusinessLogic.Service
{
    public class ServiceFactory : IServiceFactory
    {
        public IUserService UserService { get; }
        public ITokenService TokenService { get; }
        public ISecurityService SecurityService { get; }
        public INdrService NdrService { get; }
        public IPublicationService PublicationService { get; }
        public IIndividualPlanService IndividualPlanService { get; }
        public IDistributionService DistributionService { get; }

        public ServiceFactory(IUserService _userService, ITokenService _tokenService,
            ISecurityService _securityService, INdrService _ndrService, IPublicationService _publicationService, 
            IIndividualPlanService _individualPlanService, IDistributionService _distributionService)
        {
            UserService = _userService;
            TokenService = _tokenService;
            SecurityService = _securityService;
            NdrService = _ndrService;
            PublicationService = _publicationService;
            IndividualPlanService = _individualPlanService;
            DistributionService = _distributionService;
        }
    }
}
