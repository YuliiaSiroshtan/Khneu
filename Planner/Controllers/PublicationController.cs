using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Planner.DependencyInjection.ViewModels.Publication;
using Planner.ServiceInterfaces.DTO;
using Planner.ServiceInterfaces.DTO.Publication;
using Planner.ServiceInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;

namespace Planner.Controllers
{
  [Authorize]
  [Route("api/Publication")]
  public class PublicationController : GenericController
  {

    IHostingEnvironment hostingEnvironment;
    public PublicationController(IServiceFactory _serviceFactory, IMapper mapper, IHostingEnvironment _hostingEnvironment) : base(_serviceFactory, mapper)
    {
      hostingEnvironment = _hostingEnvironment;
    }


    [HttpGet]
    [Route("GetNMBDs")]
    public IActionResult GetNMBDs()
    {
      IEnumerable<NmbdDTO> result = serviceFactory.PublicationService.GetAllNmbds();
      return Ok(result);
    }

    [HttpPost]
    [Route("UpdatePublication")]
    public IActionResult UpdatePublication([FromBody] PublicationAddEditViewModel publication)
    {
      Boolean result = serviceFactory.PublicationService.UpdatePublication(_mapper.Map<PublicationAddEditDTO>(publication), UserInfo().UserName);
      return Ok(result);
    }

    [HttpGet]
    [Route("GetUserPublications")]
    public IActionResult GetUserPublications()
    {
      IEnumerable<PublicationDTO> result = serviceFactory.PublicationService.GetPublications();
      return Ok(result);
    }

    [HttpPost, DisableRequestSizeLimit]
    public ActionResult UploadFile()
    {
      String fileName = "";
      IFormFile file = Request.Form.Files[0];
      String path = Path.Combine(hostingEnvironment.WebRootPath, "publication_files");

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
    [Route("SendMessage")]
    public IActionResult SendMessage(String id)
    {
      using (var message = new MailMessage())
      {
        message.To.Add(new MailAddress("deniskovalenko96@gmail.com", "To DSpace"));
        message.From = new MailAddress("deniskovalenko96@gmail.com", "From Planner");
        message.Subject = "Publication";

        PublicationDTO result = serviceFactory.PublicationService.GetPublicationById(id);
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
