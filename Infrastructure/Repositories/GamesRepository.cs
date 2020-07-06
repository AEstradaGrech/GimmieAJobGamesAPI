using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Contracts.Repositories;
using Domain.EntitiesCF;
using Domain.Filters;
using Infrastructure.Context;
using Infrastructure.Helpers;
using Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GamesRepository : Repository<Game>, IGamesRepository
    {
        private readonly IGamesSpecificationFactory _gamesSpecificationFactory;
        private readonly IGameSortingParamExpressionFactory _sortingParamExpressionFactory;

        public GamesRepository(GAJDbContext context, IGamesSpecificationFactory specFactory,
            IGameSortingParamExpressionFactory sortingParamExpressionFactory) : base(context)
        {
            _gamesSpecificationFactory = specFactory;
            _sortingParamExpressionFactory = sortingParamExpressionFactory;
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

        public async Task<IEnumerable<Game>> GetByCatalogueFilter(CatalogueFilter filter)
        {
            var spec = await _gamesSpecificationFactory.GetCatalogueFilterSpec(filter);

            var sortingParameter = _sortingParamExpressionFactory.GetSortingParamExpresion(filter.SortingParameter);

            if (string.IsNullOrEmpty(filter.Studio))
            {

                var set = DbSet.Include(g => g.GamePromotions)
                               .ThenInclude(p => p.Promotion)
                               .Include(g => g.GameStudios)
                               .ThenInclude(gs => gs.Studio)
                               .ThenInclude(s => s.GamePromotions)
                               .ThenInclude(sp => sp.Promotion)
                               .Where(spec.SatisfiedBy());


                return filter.IsOrderByDescending ?
                       set.OrderByDescending(sortingParameter).AsEnumerable() :
                       set.OrderBy(sortingParameter).AsEnumerable();                

            }
            else
            {

                var set = DbSet.Include(g => g.GamePromotions)
                               .ThenInclude(p => p.Promotion)
                               .Include(g => g.GameStudios)
                               .ThenInclude(gs => gs.Studio)
                               .ThenInclude(s => s.GamePromotions)
                               .ThenInclude(sp => sp.Promotion)
                               .Where(result => result.GameStudios.Any(gs => gs.Studio.StudioName == filter.Studio));

                return filter.IsOrderByDescending ?
                       set.Where(spec.SatisfiedBy())
                          .OrderByDescending(sortingParameter)
                          .AsEnumerable() :
                       set.Where(spec.SatisfiedBy())
                          .OrderBy(sortingParameter)
                          .AsEnumerable();

            }
                       
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
