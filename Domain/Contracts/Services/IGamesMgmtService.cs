using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dtos;

namespace Domain.Contracts.Services
{
    public interface IGamesMgmtService
    {
        Task<IEnumerable<CatalogueGame>> GetByStudioPromotion(string studioName);
        Task<IEnumerable<CatalogueGame>> GetByPromoDesc(string promoDesc);
    }
}
