using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Dtos;

namespace GimmieAJobGamesAPI.Services
{
    public class GamesMgmtService : IGamesMgmtService
    {
        private readonly IGamesRepository _gamesRepo;

        public GamesMgmtService(IGamesRepository gamesRepo)
        {
            _gamesRepo = gamesRepo;
        }

        public async Task<IEnumerable<CatalogueGame>> GetByPromoDesc(string promoDesc)
        {
            var entities = await _gamesRepo.GetPromtedGamesByPromoDesc(promoDesc);

            return null;
        }

        public async Task<IEnumerable<CatalogueGame>> GetByStudioPromotion(string studioName)
        {
            var entities = await _gamesRepo.GetGamesByStudioPromotion(studioName);

            return null;
        }
    }
}
