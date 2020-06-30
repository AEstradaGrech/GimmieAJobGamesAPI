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

        public async Task<IEnumerable<Game>> GetAll()
        {
            return DbSet.Include(g => g.GamePromotions)
                        .ThenInclude(p => p.Promotion)
                        .Include(g => g.GameStudios)
                        .ThenInclude(gs => gs.Studio)
                        .ThenInclude(s => s.GamePromotions)
                        .ThenInclude(sp => sp.Promotion)
                        .AsEnumerable();
        }

        public async Task<Game> GetById(Guid gameId)
        {
            return await DbSet.Include(g => g.GamePromotions)
                              .ThenInclude(p => p.Promotion)
                              .Include(g => g.GameStudios)
                              .ThenInclude(gs => gs.Studio)
                              .ThenInclude(s => s.GamePromotions)
                              .ThenInclude(sp => sp.Promotion)
                              .SingleOrDefaultAsync(g => g.Id == gameId);
        }

        public async Task<IEnumerable<Game>> GetByStudioId(Guid studioId)
        {
            return DbSet.Include(g => g.GamePromotions)
                        .ThenInclude(p => p.Promotion)
                        .Include(g => g.GameStudios)
                        .ThenInclude(gs => gs.Studio)
                        .ThenInclude(s => s.GamePromotions)
                        .ThenInclude(sp => sp.Promotion)
                        .Where(result => result.GameStudios.Any(gs => gs.StudioId == studioId));                      
    }

        public async Task<IEnumerable<Game>> GetGamesByStudioPromotion(Guid studioId)
        {
            return DbSet.Include(g => g.GamePromotions)
                        .ThenInclude(p => p.Promotion)
                        .Include(g => g.GameStudios)
                        .ThenInclude(gs => gs.Studio)
                        .ThenInclude(s => s.GamePromotions)
                        .ThenInclude(sp => sp.Promotion)
                        .Where(g => g.GamePromotions.Any(p => p.StudioId == studioId));
                                         
        }

        public async Task<IEnumerable<Game>> GetPromotedGamesByPromoDesc(string promoDesc)
        {
            return DbSet.Include(g => g.GamePromotions)
                        .ThenInclude(p => p.Promotion)
                        .Include(g => g.GameStudios)
                        .ThenInclude(gs => gs.Studio)
                        .ThenInclude(s => s.GamePromotions)
                        .ThenInclude(sp => sp.Promotion)
                        .Where(g => g.GamePromotions.Any(p => p.Promotion.Description == promoDesc));
        }

        public override async Task<bool> Update(Game entity)
        {           
            return false;
        }
    }
}
