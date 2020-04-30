using System;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IDAOFactory
    {       
        Task<IGamesDAO> GetGamesDAO();
    }
}
