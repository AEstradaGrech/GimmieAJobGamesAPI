﻿using System;
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
            return DbSet.AsEnumerable();
        }

        public async Task<Game> GetById(Guid gameId)
        {
            return await DbSet.Include(g => g.GameStudios)
                              .ThenInclude(gs => gs.Studio)
                              .Include(g => g.GamePromotions)                              
                              .SingleOrDefaultAsync(g => g.Id == gameId);
        }

        public async Task<IEnumerable<Game>> GetByStudioId(Guid studioId)
        {
            var response = DbSet.Include(g => g.GameStudios)
                        .ThenInclude(gs => gs.Studio)
                        .Where(s => s.Id == studioId)
                        .ToList();

            return response;
        }

        public async Task<IEnumerable<Game>> GetGamesByStudioPromotion(Guid studioId)
        {
            return DbSet.Include(g => g.GamePromotions)
                        .ThenInclude(p => p.Promotion)
                        .Where(g => g.GamePromotions.Any(p => p.StudioId == studioId));
                                         
        }

        public async Task<IEnumerable<Game>> GetPromotedGamesByPromoDesc(string promoDesc)
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
