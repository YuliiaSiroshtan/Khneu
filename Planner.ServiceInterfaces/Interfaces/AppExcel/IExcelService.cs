using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppExcel
{
    public interface IExcelService
    {
        void Write(IEnumerable<FullTimeEntryLoadDto> fullTimeEntryLoads,
            IEnumerable<PartTimeEntryLoadDto> partTimeEntryLoads, string path);

        Task Read(string path);

        void Save(string path);
    }
}