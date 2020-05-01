using System;
using System.Data.Entity.Core.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Dtos;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Infrastructure.DAO
{
    public class GamesDAO : IGamesDAO
    {
        private readonly GAJGamesDbContext _context;

        public GamesDAO(GAJGamesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CatalogueGame>> GetGamesByPEGI(int PEGI)
        {
            return await QueryGames("GetGamesByPEGI", "{PEGI}", PEGI.ToString());
        }

        public async Task<IEnumerable<CatalogueGame>> GetGamesByPromoDesc(string promoDesc)
        {
            return await QueryGames("GetGamesByPromoDesc", "{promoDesc}", promoDesc);
        }

        public async Task<IEnumerable<CatalogueGame>> GetGamesByStudioPromotion(string studioName)
        {
            return await QueryGames("GetPromotedGamesByStudioName", "{studioName}", studioName);
        }

        public async Task<IEnumerable<CatalogueGame>> GetStudioGames(string studioName)
        {
            return await QueryGames("GetStudioGamesByName", "{studioName}", studioName);            
        }

        private async Task<IEnumerable<CatalogueGame>> QueryGames(string queryName, string queryParam, string paramToReplace)
        {
            try
            {

                var query = await _context.Queries.SingleOrDefaultAsync(q => q.QueryName == queryName);

                var queryText = query.Query.Replace($"{queryParam}", $"'{paramToReplace}");

                var result = _context.Query<CatalogueGame>()
                                     .FromSql(queryText)
                                     .AsEnumerable();

                return result;
            }
            catch (Exception ex)
            {
                Console.Write($"{ex.Message}");

                if (ex.InnerException != null)
                    Console.Write($"{ex.InnerException.Message}");
            }

            return null;
        }
    }
}
