using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dtos;

namespace Domain.Contracts
{
    public interface IGamesDAO
    {
        Task<IEnumerable<CatalogueGame>> GetStudioGames(string studioName);
        Task<IEnumerable<CatalogueGame>> GetGamesByPromoDesc(string promoDesc);
        Task<IEnumerable<CatalogueGame>> GetGamesByStudioPromotion(string studioName);
        Task<IEnumerable<CatalogueGame>> GetGamesByPEGI(int PEGI);
    }
}
