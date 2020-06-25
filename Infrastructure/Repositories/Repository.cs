using System;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Contracts.Repositories;
using Domain.EntitiesCF;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        private DbSet<T> _dbSet;
        private IUnitOfWork _uoW;

        public DbSet<T> DbSet { get => _dbSet; }
        public IUnitOfWork UoW { get => _uoW; }

        public Repository(GAJDbContext context)
        {
            _dbSet = context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            if(!await _dbSet.AnyAsync(e => e.Id == entity.Id))
            {
                var newEntity = await _dbSet.AddAsync(entity);

                return await _uoW.SaveEntitiesAsync() ?
                       await _dbSet.FindAsync(newEntity.Entity.Id) : null;
            }

            return null;
        }

        public async Task<T> Remove(T entity)
        {
            if(await _dbSet.AnyAsync(e => e.Id == entity.Id))
            {
                var entityToRemove = _dbSet.Remove(entity);

                return await _uoW.SaveEntitiesAsync() ? entityToRemove.Entity : null;
            }

            return null;
        }

        public abstract Task<bool> Update(T entity);
    }
}
