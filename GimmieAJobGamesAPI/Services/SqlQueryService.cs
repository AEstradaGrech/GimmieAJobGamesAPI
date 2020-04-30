using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Dtos;

namespace GimmieAJobGamesAPI.Services
{
    public class SqlQueryService : ISqlQueryService
    {
        private readonly IDAOFactory _DAOFactory;

        public SqlQueryService(IDAOFactory daoFactory)
        {
            _DAOFactory = daoFactory;
        }

        public async Task<IEnumerable<CatalogueGame>> GetStudioGames(string studioName)
        {
            var gamesDao = await _DAOFactory.GetGamesDAO();

            return await gamesDao.GetStudioGames(studioName);            
        }
    }
}
