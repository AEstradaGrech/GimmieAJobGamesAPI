using System;
using System.Threading.Tasks;
using Domain.Contracts;
using Infrastructure.Context;

namespace Infrastructure.DAO
{
    public class MySqlDAOFactory : DAOFactory
    {
        public MySqlDAOFactory(GAJGamesDbContext context) : base(context) { }

        public override async Task<IGamesDAO> GetGamesDAO()
        {
            return new GamesDAO(DbContext);
        }
           
    }
}
