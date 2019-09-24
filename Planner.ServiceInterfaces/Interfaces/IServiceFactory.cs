namespace Planner.ServiceInterfaces.Interfaces
{
    public interface IServiceFactory
    {
        IUserService UserService { get; }
        ITokenService TokenService { get; }
        ISecurityService SecurityService { get; }
        INdrService NdrService { get; }
        IPublicationService PublicationService { get; }
        IIndividualPlanService IndividualPlanService { get; }
        IDistributionService DistributionService { get; }
    }
}
