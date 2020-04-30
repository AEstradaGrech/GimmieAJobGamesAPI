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

        public async Task<IEnumerable<CatalogueGame>> GetStudioGames(string studioName)
        {
            try
            {

                var query = $@"USE GAJGamesDb;
                               SELECT g.Title, g.Genre, g.PEGI, g.Price FROM Games AS g
			                   INNER JOIN StudioGame AS relTb ON relTb.GameId = g.Id
			                   INNER JOIN Studios AS s ON relTb.StudioId = s.Id
			                   WHERE s.StudioName LIKE '{studioName}%';";

                var result = _context.Query<CatalogueGame>()
                                     .FromSql(query)
                                     .AsEnumerable();

                return result;
            }
            catch(Exception ex)
            {
                Console.Write($"{ex.Message}");

                if (ex.InnerException != null)
                    Console.Write($"{ex.InnerException.Message}");
            }

            return null;            
        }
    }
}
