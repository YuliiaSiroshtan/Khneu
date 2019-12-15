using Microsoft.AspNetCore.Http;

namespace Planner.Entities.Mics
{
    public class FileInfoModel
    {
        public IFormFile File { get; set; }

        public int HoursPerRate { get; set; }
    }
}