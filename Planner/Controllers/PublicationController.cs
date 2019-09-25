using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Planner.DependencyInjection.ViewModels.Publication;
using Planner.ServiceInterfaces.DTO.Publication;
using Planner.ServiceInterfaces.Interfaces;
using System;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Planner.Controllers
{
  [Authorize]
  [Route("api/Publication")]
  public class PublicationController : GenericController
  {

    private readonly IHostingEnvironment _hostingEnvironment;
    public PublicationController(IServiceFactory serviceFactory,
      IMapper mapper,
      IHostingEnvironment hostingEnvironment) : base(serviceFactory, mapper)
    {
      _hostingEnvironment = hostingEnvironment;
    }


    [HttpGet]
    [Route("GetNMBDs")]
    public async Task<IActionResult> GetNMBDs()
    {
      var result = await ServiceFactory.PublicationService.GetAllNmbds();

      return Ok(result);
    }

    [HttpPost]
    [Route("UpdatePublication")]
    public async Task<IActionResult> UpdatePublication([FromBody] PublicationAddEditViewModel publication)
    {
      var result = await ServiceFactory.PublicationService.UpdatePublication(Mapper.Map<PublicationAddEditDTO>(publication), UserInfo().UserName);

      return Ok(result);
    }

    [HttpGet]
    [Route("GetUserPublications")]
    public async Task<IActionResult> GetUserPublications()
    {
      var result = await ServiceFactory.PublicationService.GetPublications();

      return Ok(result);
    }

    [HttpPost, DisableRequestSizeLimit]
    public ActionResult UploadFile()
    {
      var fileName = "";
      var file = Request.Form.Files[0];
      var path = Path.Combine(_hostingEnvironment.WebRootPath, "publication_files");

      if (file.Length <= 0) return Json(fileName);

      fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
      var fullPath = Path.Combine(path, fileName);

      using (var stream = new FileStream(fullPath, FileMode.Create))
      {
        file.CopyTo(stream);
      }

      return Json(fileName);
    }

    [HttpGet]
    [Route("SendMessage")]
    public async Task<IActionResult> SendMessage(String id)
    {
      using (var message = new MailMessage())
      {
        message.To.Add(new MailAddress("deniskovalenko96@gmail.com", "To DSpace"));
        message.From = new MailAddress("deniskovalenko96@gmail.com", "From Planner");
        message.Subject = "Publication";

        var result = await ServiceFactory.PublicationService.GetPublicationById(id);
        message.Body = JsonConvert.SerializeObject(result);

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
