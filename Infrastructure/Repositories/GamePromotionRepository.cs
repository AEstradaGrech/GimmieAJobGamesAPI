using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Contracts.Repositories;
using Domain.EntitiesCF;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class GamePromotionRepository : Repository<GamePromotion>, IGamePromotionRepository
    {
        public GamePromotionRepository(GAJDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<GamePromotion>> GetByAccountType(AccountTypes accountType)
        {
            return DbSet.Where(p => p.AccountType == accountType);
        }

        public async Task<IEnumerable<GamePromotion>> GetByGameId(Guid gameId)
        {
            return DbSet.Where(p => p.GameId == gameId);
        }

        public async Task<IEnumerable<GamePromotion>> GetByStudioId(Guid studioId)
        {
            return DbSet.Where(p => p.StudioId == studioId);
        }

        public async override Task<bool> Update(GamePromotion entity)
        {
            throw new NotImplementedException();
        }
    }
}
