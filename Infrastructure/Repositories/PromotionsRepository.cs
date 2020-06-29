using System;
using System.Threading.Tasks;
using Domain.Contracts.Repositories;
using Domain.EntitiesCF;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class PromotionsRepository : Repository<Promotion>, IPromotionsRepository
    {
        public PromotionsRepository(GAJDbContext context) : base(context)
        {
        }

        public async override Task<bool> Update(Promotion entity)
        {
            throw new NotImplementedException();
        }
    }
}
