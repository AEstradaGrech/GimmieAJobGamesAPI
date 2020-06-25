﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.EntitiesCF;

namespace Domain.Contracts.Repositories
{
    public interface IGamesRepository : IRepository<Game>
    {
        Task<IEnumerable<Game>> GetGamesByStudioPromotion(Guid studioId);
        Task<IEnumerable<Game>> GetPromtedGamesByPromoDesc(string promoDesc);
    }
}