using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Contracts.Mappers;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Dtos;
using Domain.EntitiesCF;

namespace GimmieAJobGamesAPI.Services
{
    public class GamePromotionsMgmtService : IGamePromotionsMgmtService
    {
        private readonly IGamePromotionRepository _promotionsRepo;
        private readonly IGamePromotionsMapperService _promotionsMapper;

        public GamePromotionsMgmtService(IGamePromotionsMapperService promotionsMapper,
            IGamePromotionRepository promotionsRepo)
        {
            _promotionsRepo = promotionsRepo;
            _promotionsMapper = promotionsMapper;
        }

        public async Task<IEnumerable<GamePromotionDto>> GetByAccountType(AccountTypes accountType)
        {
            return await _promotionsMapper.MapManyToDto(await _promotionsRepo.GetByAccountType(accountType));
        }

        public async Task<IEnumerable<GamePromotionDto>> GetByGameId(Guid gameId)
        {
            return await _promotionsMapper.MapManyToDto(await _promotionsRepo.GetByGameId(gameId));
        }

        public async Task<IEnumerable<GamePromotionDto>> GetByStudioId(Guid studioId)
        {
            return await _promotionsMapper.MapManyToDto(await _promotionsRepo.GetByStudioId(studioId));
        }
    }
}
