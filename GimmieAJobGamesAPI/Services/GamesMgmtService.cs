using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Contracts.Mappers;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Dtos;
using Domain.Filters;

namespace GimmieAJobGamesAPI.Services
{
    public class GamesMgmtService : IGamesMgmtService
    {
        private readonly IGamesRepository _gamesRepo;
        private readonly IStudiosRepository _studiosRepo;
        private readonly IGamesMapperService _gamesMapper;

        public GamesMgmtService(IGamesRepository gamesRepo, IStudiosRepository studiosRepo,
            IGamesMapperService gamesMapper)
        {
            _gamesRepo = gamesRepo;
            _studiosRepo = studiosRepo;
            _gamesMapper = gamesMapper;
        }

        public async Task<IEnumerable<CatalogueGameDto>> GetAllCatalogueGames()
        {
            return await _gamesMapper.MapManyToCatalogueGame(await _gamesRepo.GetAll());
        }

        public async Task<CatalogueResponseDto> GetByCatalogueFilter(CatalogueFilter filter)
        {
            var games = await _gamesRepo.GetByCatalogueFilter(filter);

            var dtos = await _gamesMapper.MapManyToCatalogueGame(games.Skip(filter.Skip).Take(filter.ChunkSize));

            return new CatalogueResponseDto { Games = dtos.ToList(), TotalCount = games.Count() };
        }

        public async Task<IEnumerable<CatalogueGameDto>> GetCatalogueGameByPromoDesc(string promoDesc)
        {
            var entities = await _gamesRepo.GetPromotedGamesByPromoDesc(promoDesc);
           
            return await _gamesMapper.MapManyToCatalogueGame(entities);
        }

        public async Task<IEnumerable<CatalogueGameDto>> GetCatalogueGameByStudioName(string studioName)
        {
            var studio = await _studiosRepo.GetStudioByName(studioName);

            return studio != null ? await _gamesMapper.MapManyToCatalogueGame(await _gamesRepo.GetByStudioId(studio.Id)) : null;
        }

        public async Task<IEnumerable<CatalogueGameDto>> GetCatalogueGameByStudioPromotion(string studioName)
        {
            var studioId = await _studiosRepo.GetStudioByName(studioName);

            if(studioId != null)
            {
                var games = await _gamesRepo.GetGamesByStudioPromotion(studioId.Id);

                return await _gamesMapper.MapManyToCatalogueGame(games);
            }

            return null;
        }

        public async Task<GameDetailDto> GetGameDetailByGameId(Guid gameId)
        {
            return await _gamesMapper.MapToDto(await _gamesRepo.GetById(gameId));
        }
    }
}
