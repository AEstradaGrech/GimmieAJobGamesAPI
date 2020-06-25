using System;
using System.Threading.Tasks;
using Domain.EntitiesCF;

namespace Domain.Contracts.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> Add(T entity);
        Task<T> Remove(T entity);
        Task<bool> Update(T entity);
    }
}
