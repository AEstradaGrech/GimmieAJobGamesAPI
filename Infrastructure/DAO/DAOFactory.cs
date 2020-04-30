using System;
using System.Threading.Tasks;
using Domain.Contracts;
using Infrastructure.Context;

namespace Infrastructure.DAO
{
    public abstract class DAOFactory : IDAOFactory
    {        
        private GAJGamesDbContext _context;

        public GAJGamesDbContext DbContext { get => _context; }
               

        public DAOFactory(GAJGamesDbContext context)
        {
            _context = context;
        }

        public abstract Task<IGamesDAO> GetGamesDAO();
    }
}
