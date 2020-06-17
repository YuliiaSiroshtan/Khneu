using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Planner.Entities.DTO.AppPublicationDto;
using Planner.ServiceInterfaces.Interfaces.Misc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Planner.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  public class PublicationController : GenericController
  {
    private readonly IHostingEnvironment hostingEnvironment;

    public PublicationController(IServiceScope serviceScope) : base(serviceScope) { }


    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetNMBDs()
    {
      IEnumerable<NmbdDTO> result = await ServiceScope.PublicationService.GetAllNmbds();
      return Ok(result);
    }

    //[HttpPost]
    //[Route("[action]")]
    //public async Task<IActionResult> UpdatePublication([FromBody] PublicationAddEditViewModel publication)
    //{
    //  Boolean result = serviceFactory.PublicationService.UpdatePublication(_mapper.Map<PublicationAddEditDTO>(publication), UserInfo().UserName);
    //  return Ok(result);
    //}

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetUserPublications()
    {
      IEnumerable<PublicationDTO> result = await ServiceScope.PublicationService.GetPublications(this.UserInfo().Login);
      return Ok(result);
    }


    [HttpPost, DisableRequestSizeLimit]
    public ActionResult UploadFile()
    {
      string fileName = "";
      IFormFile file = Request.Form.Files[0];
      string path = Path.Combine(hostingEnvironment.WebRootPath, "publication_files");

      if (file.Length > 0)
      {
        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        string fullPath = Path.Combine(path, fileName);
        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
          file.CopyTo(stream);
        }
      }
      return Json(fileName);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> SendMessage(string id)
    {
      using (var message = new MailMessage())
      {
        message.To.Add(new MailAddress("deniskovalenko96@gmail.com", "To DSpace"));
        message.From = new MailAddress("deniskovalenko96@gmail.com", "From Planner");
        message.Subject = "Publication";

        PublicationDTO result = await ServiceScope.PublicationService.GetPublicationById(id);
        message.Body = JsonConvert.SerializeObject(result);
        //message.Body = "New publication";
        //message.IsBodyHtml = true;
        message.IsBodyHtml = false;

        using (var client = new SmtpClient("smtp.gmail.com"))
        {
          client.Port = 587;
          client.Credentials = new NetworkCredential("deniskovalenko96@gmail.com", "rjdfktyrj24912696");
          client.EnableSsl = true;
          client.Send(message);
        }
      }

      return Ok(true);
    }
  }
}
