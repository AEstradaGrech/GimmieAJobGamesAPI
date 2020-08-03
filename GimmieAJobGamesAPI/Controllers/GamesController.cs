using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.Contracts.Services;
using Domain.Filters;
using GimmieAJobGamesAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace GimmieAJobGamesAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGamesMgmtService _gamesMgmtService;

        public GamesController(IGamesMgmtService gamesMgmtService)
        {
            _gamesMgmtService = gamesMgmtService;
        }


        [HttpGet]
        [Route("get-full-catalogue")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetFullCatalogue()
        {
            var response = await _gamesMgmtService.GetAllCatalogueGames();

            if (response != null)
                return Ok(response);

            return BadRequest();
        }

       [HttpGet]
       [Route("get-by-studio-name")]
       [ProducesResponseType((int)HttpStatusCode.OK)]
       [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetByStudioName([FromQuery]string studioName)
        {
            var response = await _gamesMgmtService.GetCatalogueGameByStudioName(studioName);

            if (response != null)
                return Ok(response);

            return BadRequest();
        }

        [HttpGet]
        [Route("get-by-promo-desc")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetByPromoDesc([FromQuery]string promoDesc)
        {
            var response = await _gamesMgmtService.GetCatalogueGameByPromoDesc(promoDesc);

            if (response != null)
                return Ok(response);

            return BadRequest();
        }

        [HttpGet]
        [Route("get-game-detail")]
        [Authorize(Policy = "Anonymous")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetGameDetail([FromQuery]Guid gameId)
        {
            var response = await _gamesMgmtService.GetGameDetailByGameId(gameId);

            if (response != null)
                return Ok(response);

            return BadRequest();
        }

        //[HttpGet]
        //[Route("get-by-PEGI")]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public async Task<IActionResult> GetByPEGI([FromQuery]int PEGI)
        //{
        //    var response = await _sqlService.GetGamesByPEGI(PEGI);

        //    if (response != null)
        //        return Ok(response);

        //    return BadRequest();
        //}

        [HttpGet]
        [Route("get-promoted-by-studio-name")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPromotedByStudioName([FromQuery]string studioName)
        {
            var response = await _gamesMgmtService.GetCatalogueGameByStudioPromotion(studioName);

            if (response != null)
                return Ok(response);

            return BadRequest();
        }

        [HttpPost]
        [Route("get-by-catalogue-filter")]
        [Authorize("Anonymous")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetByCatalogueFilter([FromBody]CatalogueFilter filter)
        {
            var response = await _gamesMgmtService.GetByCatalogueFilter(filter);

            if (response != null)
                return Ok(response);

            return BadRequest();
        }

        [HttpGet]
        [Route("get-game-genres")]
        [Authorize("Anonymous")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetGameGenres()
        {
            var response = await _gamesMgmtService.GetGameGenres();

            if (response != null)
                return Ok(response);

            return BadRequest();
        }
    }
}
