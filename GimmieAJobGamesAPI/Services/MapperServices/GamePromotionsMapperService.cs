using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Contracts.Mappers;
using Domain.Dtos;
using Domain.EntitiesCF;

namespace GimmieAJobGamesAPI.Services.MapperServices
{
    public class GamePromotionsMapperService : IGamePromotionsMapperService
    {
        public GamePromotionsMapperService()
        {
        }

        public async Task<IEnumerable<GamePromotionDto>> MapManyToDto(IEnumerable<GamePromotion> entities)
        {
            var dtos = new List<GamePromotionDto>();

            foreach(var e in entities) { dtos.Add(await MapToDto(e)); }

            return dtos;
        }

        public Task<IEnumerable<GamePromotion>> MapManyToEntity(IEnumerable<GamePromotionDto> dtos)
        {
            throw new NotImplementedException();
        }

        public async Task<GamePromotionDto> MapToDto(GamePromotion entity)
        {
            var dto = new GamePromotionDto
            {
                Description = entity.Promotion.Description,
                Discount = entity.Promotion.Discount,
                AccountType = entity.AccountType,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate
            };

            return dto;
        }

        public Task<GamePromotion> MapToEntity(GamePromotionDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
