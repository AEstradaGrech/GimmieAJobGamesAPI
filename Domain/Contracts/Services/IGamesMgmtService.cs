using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Filters;

namespace Domain.Contracts.Services
{
    public interface IGamesMgmtService
    {
        Task<IEnumerable<CatalogueGameDto>> GetAllCatalogueGames();
        Task<IEnumerable<CatalogueGameDto>> GetCatalogueGameByStudioPromotion(string studioName);
        Task<IEnumerable<CatalogueGameDto>> GetCatalogueGameByStudioName(string studioName);
        Task<IEnumerable<CatalogueGameDto>> GetCatalogueGameByPromoDesc(string promoDesc);
        Task<GameDetailDto> GetGameDetailByGameId(Guid gameId);
        Task<CatalogueResponseDto> GetByCatalogueFilter(CatalogueFilter filter);
        Task<IEnumerable<string>> GetGameGenres();

    }
}
