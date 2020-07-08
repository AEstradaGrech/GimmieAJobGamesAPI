using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.EntitiesCF;

namespace Domain.Contracts.Services
{
    public interface IGamePromotionsMgmtService
    {
        Task<IEnumerable<GamePromotionDto>> GetByStudioId(Guid studioId);
        Task<IEnumerable<GamePromotionDto>> GetByAccountType(AccountTypes accountType);
        Task<IEnumerable<GamePromotionDto>> GetByGameId(Guid gameId);
    }
}
