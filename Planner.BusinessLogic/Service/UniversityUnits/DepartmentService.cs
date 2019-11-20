using AutoMapper;
using Planner.Entities.DTO.UniversityUnits;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.UniversityUnits;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.UniversityUnits
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentDto>> GetDepartments()
        {
            var departments = await _uow.DepartmentRepository.GetDepartments();

            return _mapper.Map<IEnumerable<DepartmentDto>>(departments);
        }

        public async Task<DepartmentDto> GetDepartmentById(int id)
        {
            var department = await _uow.DepartmentRepository.GetDepartmentById(id);

            return _mapper.Map<DepartmentDto>(department);
        }

        public async Task<DepartmentDto> GetDepartmentByName(string name)
        {
            var department = await _uow.DepartmentRepository.GetDepartmentByName(name);

            return _mapper.Map<DepartmentDto>(department);
        }
    }
}
