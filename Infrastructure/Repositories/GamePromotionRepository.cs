using System;
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

        public async override Task<bool> Update(GamePromotion entity)
        {
            throw new NotImplementedException();
        }
    }
}
