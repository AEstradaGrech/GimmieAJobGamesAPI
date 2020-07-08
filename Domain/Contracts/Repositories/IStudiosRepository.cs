using System;
using System.Threading.Tasks;
using Domain.EntitiesCF;

namespace Domain.Contracts.Repositories
{
    public interface IStudiosRepository : IRepository<Studio>
    {
        Task<Studio> GetStudioByName(string studioName);
    }
}
