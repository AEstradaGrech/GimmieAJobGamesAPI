using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Contracts.Repositories;
using Domain.EntitiesCF;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class StudiosRepository : Repository<Studio>, IStudiosRepository
    {
        public StudiosRepository(GAJDbContext context) : base(context)
        {
        }

        public async Task<Studio> GetStudioByName(string studioName)
        {
            return await DbSet.SingleOrDefaultAsync(s => s.StudioName == studioName);
        }

        public async override Task<bool> Update(Studio entity)
        {
            throw new NotImplementedException();
        }
    }
}
