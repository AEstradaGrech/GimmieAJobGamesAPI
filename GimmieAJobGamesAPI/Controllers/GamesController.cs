using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GimmieAJobGamesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace GimmieAJobGamesAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly ISqlQueryService _sqlService;

        public GamesController(ISqlQueryService sqlService)
        {
            _sqlService = sqlService;
        }

        // GET: api/values
        [HttpGet]
        [Route("get-by-studio-name")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult>GetByStudioName([FromQuery]string studioName)
        {
            var response = await _sqlService.GetStudioGames(studioName);

            if (response != null)
                return Ok(response);

            return BadRequest();
        }
    }
}
