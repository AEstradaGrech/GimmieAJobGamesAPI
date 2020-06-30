using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.EntitiesCF;

namespace Domain.Contracts.Repositories
{
    public interface IGamePromotionRepository : IRepository<GamePromotion>
    {
        Task<IEnumerable<GamePromotion>> GetByStudioId(Guid studioId);
        Task<IEnumerable<GamePromotion>> GetByAccountType(AccountTypes accountType);
        Task<IEnumerable<GamePromotion>> GetByGameId(Guid gameId);
    }
}
