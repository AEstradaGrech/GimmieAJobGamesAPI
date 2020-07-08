using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Contracts.Mappers;
using Domain.Dtos;
using Domain.EntitiesCF;

namespace GimmieAJobGamesAPI.Services.MapperServices
{
    public class GameStudiosMapperService : IGameStudiosMapperService
    {
        public GameStudiosMapperService()
        {
        }

        public Task<IEnumerable<GamePromotionDto>> MapManyToDto(IEnumerable<GamePromotion> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GamePromotion>> MapManyToEntity(IEnumerable<GamePromotionDto> dtos)
        {
            throw new NotImplementedException();
        }

        public async Task<GamePromotionDto> MapToDto(GamePromotion entity)
        {
            return null;
        }

        public Task<GamePromotion> MapToEntity(GamePromotionDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
