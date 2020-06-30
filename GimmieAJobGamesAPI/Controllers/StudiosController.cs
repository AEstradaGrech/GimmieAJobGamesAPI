using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.Contracts.Mappers;
using Domain.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GimmieAJobGamesAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class StudiosController : ControllerBase
    {
        private readonly IStudiosMgmtService _studiosMgmtService;

        public StudiosController(IStudiosMgmtService studiosMgmtService)
        {
            _studiosMgmtService = studiosMgmtService;
        }

        [HttpGet]
        [Route("get-studio-by-name")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetStudioByName([FromQuery]string studioName)
        {
            var response = await _studiosMgmtService.GetByName(studioName);

            if (response != null)
                return Ok(response);

            return BadRequest();
        }

    }
}
