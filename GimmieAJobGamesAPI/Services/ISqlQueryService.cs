using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dtos;

namespace GimmieAJobGamesAPI.Services
{
    public interface ISqlQueryService
    {
        Task<IEnumerable<CatalogueGame>> GetStudioGames(string studioName);
        Task<IEnumerable<CatalogueGame>> GetGamesByPEGI(int PEGI);
        Task<IEnumerable<CatalogueGame>> GetGamesByPromoDesc(string promoDesc);
        Task<IEnumerable<CatalogueGame>> GetPromotedGamesByStudioName(string studioName);
    }
}
