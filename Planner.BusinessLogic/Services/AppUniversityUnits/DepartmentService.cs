using AutoMapper;
using Planner.BusinessLogic.Services.Base;
using Planner.Entities.DTO.UniversityUnits;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces.UniversityUnits;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Services.AppUniversityUnits
{
    public class DepartmentService : BaseService, IDepartmentService
    {
        public DepartmentService(IRepositoryScope repositoryScope, IMapper mapper) : base(repositoryScope, mapper) { }

        public async Task<IEnumerable<DepartmentDto>> GetDepartments()
        {
            var departments = await this.RepositoryScope.DepartmentRepository.GetDepartments();

            return this.Mapper.Map<IEnumerable<DepartmentDto>>(departments);
        }

        public async Task<DepartmentDto> GetDepartmentById(int id)
        {
            var department = await this.RepositoryScope.DepartmentRepository.GetDepartmentById(id);

            return this.Mapper.Map<DepartmentDto>(department);
        }

        public async Task<DepartmentDto> GetDepartmentByName(string name)
        {
            var department = await this.RepositoryScope.DepartmentRepository.GetDepartmentByName(name);

            return this.Mapper.Map<DepartmentDto>(department);
        }
    }
}