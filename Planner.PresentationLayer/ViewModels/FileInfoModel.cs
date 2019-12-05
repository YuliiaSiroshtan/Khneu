using Microsoft.AspNetCore.Http;

namespace Planner.PresentationLayer.ViewModels
{
    public class FileInfoModel
    {
        public IFormFile File { get; set; }

        public int HoursPerRate { get; set; }
    }
}