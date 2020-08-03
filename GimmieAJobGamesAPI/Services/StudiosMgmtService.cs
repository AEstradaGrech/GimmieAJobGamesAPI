using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Contracts.Mappers;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Dtos;

namespace GimmieAJobGamesAPI.Services
{
    public class StudiosMgmtService : IStudiosMgmtService
    {
        private readonly IStudiosRepository _studiosRepo;
        private readonly IStudiosMapperService _studiosMapper;
        private readonly IGamesMgmtService _gamesMgmtService;

        public StudiosMgmtService(IStudiosRepository studiosRepo, IStudiosMapperService studiosMapper,
            IGamesMgmtService gamesMgmtService)
        {
            _studiosRepo = studiosRepo;
            _studiosMapper = studiosMapper;
            _gamesMgmtService = gamesMgmtService;
        }

        public async Task<StudioDto> GetByName(string studioName)
        {
            var studioGames = await _gamesMgmtService.GetCatalogueGameByStudioName(studioName);

            var studio = await _studiosMapper.MapToDto(await _studiosRepo.GetStudioByName(studioName));

            studio.StudioGames = studioGames as List<CatalogueGameDto>;

            return studio;
        }

        public async Task<IEnumerable<string>> GetStudioNames()
        {
            return await _studiosRepo.GetStudioNames();
        }
    }
}
