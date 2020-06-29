using System;
using System.Threading.Tasks;
using Domain.Contracts.Repositories;
using Domain.EntitiesCF;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class GameStudioRepository : Repository<GameStudio>, IGameStudioRepository
    {
        public GameStudioRepository(GAJDbContext context):base(context)
        {
        }

        public async override Task<bool> Update(GameStudio entity)
        {
            throw new NotImplementedException();
        }
    }
}
