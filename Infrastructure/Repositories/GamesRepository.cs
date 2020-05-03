using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Contracts.Repositories;
using Domain.EntitiesCF;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GamesRepository : Repository<Game>, IGamesRepository
    {
        public GamesRepository(GAJDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Game>> GetGamesByStudioPromotion(string studioName)
        {
            return DbSet.Include(g => g.GamePromotions)
                        .ThenInclude(p => p.Promotion)
                        .Where(g => g.GamePromotions.Any(p => p.Studio.StudioName == studioName));
                                         
        }

        public async Task<IEnumerable<Game>> GetPromtedGamesByPromoDesc(string promoDesc)
        {
            return DbSet.Include(g => g.GamePromotions)
                        .ThenInclude(p => p.Promotion)
                        .Where(g => g.GamePromotions.Any(p => p.Promotion.Description == promoDesc));
        }

        public override async Task<bool> Update(Game entity)
        {           
            return false;
        }
    }
}
