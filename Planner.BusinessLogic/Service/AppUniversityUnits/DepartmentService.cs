using AutoMapper;
using Planner.BusinessLogic.Service.Base;
using Planner.Entities.DTO.UniversityUnits;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.UniversityUnits;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppUniversityUnits
{
    public class DepartmentService : BaseService, IDepartmentService
    {
        public DepartmentService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public async Task<IEnumerable<DepartmentDto>> GetDepartments()
        {
            var departments = await this.Uow.DepartmentRepository.GetDepartments();

            return this.Mapper.Map<IEnumerable<DepartmentDto>>(departments);
        }

        public async Task<DepartmentDto> GetDepartmentById(int id)
        {
            var department = await this.Uow.DepartmentRepository.GetDepartmentById(id);

            return this.Mapper.Map<DepartmentDto>(department);
        }

        public async Task<DepartmentDto> GetDepartmentByName(string name)
        {
            var department = await this.Uow.DepartmentRepository.GetDepartmentByName(name);

            return this.Mapper.Map<DepartmentDto>(department);
        }
    }
}