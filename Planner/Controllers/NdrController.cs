using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Planner.Entities.DTO.AppNdrDto;
using Planner.ServiceInterfaces.Interfaces.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Controllers
{
  [Route("api/[controller]")]
  public class NdrController : GenericController
  {
    private readonly IMapper _mapper;
    public NdrController(IServiceScope serviceScope, IMapper mapper) : base(serviceScope)
    {
      _mapper = mapper;
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> AddNdr([FromBody] NdrDTO registerNdrDTO)
    {
      if (registerNdrDTO == null) return BadRequest();

      var res = await ServiceScope.NdrService.AddNdr(registerNdrDTO);

      return res == 0 ? BadRequest() : (IActionResult)Ok("Ndr added!");
    }


    [HttpGet]
    [Route("[action]")]
    [Authorize]
    public async Task<IActionResult> GetUserNdr()
    {
      IEnumerable<NdrListDTO> ndrs = await ServiceScope.NdrService.GetUserNdr(this.UserInfo().Login);
      IEnumerable<NdrListDTO> ndrModel = _mapper.Map<IEnumerable<NdrListDTO>>(ndrs);
      return Ok(ndrModel);
    }
  }
}
