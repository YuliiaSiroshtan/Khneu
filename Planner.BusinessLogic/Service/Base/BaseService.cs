using AutoMapper;
using Planner.RepositoryInterfaces.UoW;

namespace Planner.BusinessLogic.Service.Base
{
    public class BaseService
    {
        protected readonly IMapper Mapper;
        protected readonly IUnitOfWork Uow;

        protected BaseService(IUnitOfWork uow, IMapper mapper)
        {
            this.Uow = uow;
            this.Mapper = mapper;
        }
    }
}