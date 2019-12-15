using AutoMapper;
using Planner.RepositoryInterfaces.Interfaces.Misc;

namespace Planner.BusinessLogic.Services.Base
{
    public class BaseService
    {
        protected readonly IMapper Mapper;
        protected readonly IRepositoryScope RepositoryScope;

        protected BaseService(IRepositoryScope repositoryScope, IMapper mapper)
        {
            this.RepositoryScope = repositoryScope;
            this.Mapper = mapper;
        }
    }
}