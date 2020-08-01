using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Contracts.Mappers;
using Domain.Dtos;
using Domain.EntitiesCF;
using Omu.ValueInjecter;

namespace GimmieAJobGamesAPI.Services.MapperServices
{
    public class GamesMapperService : IGamesMapperService
    {
        private readonly IStudiosMapperService _studiosMapper;
        private readonly IGamePromotionsMapperService _promotionsMapper;

        public GamesMapperService(IStudiosMapperService studiosMapper, IGamePromotionsMapperService promotionsMapper)
        {
            _studiosMapper = studiosMapper;
            _promotionsMapper = promotionsMapper;
        }

        public async Task<IEnumerable<GameDetailDto>> MapManyToDto(IEnumerable<Game> entities)
        {
            var dtos = new List<GameDetailDto>();

            foreach (var entity in entities) { dtos.Add(await MapToDto(entity));}

            return dtos.AsEnumerable();            
        }

        public async Task<IEnumerable<Game>> MapManyToEntity(IEnumerable<GameDetailDto> dtos)
        {
            var entities = new List<Game>();

            foreach (var dto in dtos) { entities.Add(await MapToEntity(dto)); }

            return entities;
        }
        
        public async Task<GameDetailDto> MapToDto(Game entity)
        {
            var dto = new GameDetailDto();

            dto = (GameDetailDto)dto.InjectFrom(entity);

            var studioPromos = await GetStudioPromotions(entity);

            dto.GameStudios = await _studiosMapper.MapManyToDto(entity.GameStudios.Select(x => x.Studio)) as List<StudioDto>;

            dto.GamePromotions = await _promotionsMapper.MapManyToDto(entity.GamePromotions) as List<GamePromotionDto>;

            studioPromos.ToList().ForEach(sp => dto.GamePromotions.Add(sp));
          
            return dto;
        }

        public async Task<Game> MapToEntity(GameDetailDto dto)
        {
            var entity = new Game();

            return (Game)entity.InjectFrom(dto);
        }      

        public async Task<CatalogueGameDto> MapToCatalogueGame(Game entity)
        {
            var dto = new CatalogueGameDto();

            dto = (CatalogueGameDto)dto.InjectFrom(entity);

            var studioPromos = await GetStudioPromotions(entity);

            dto.GamePromotions = await _promotionsMapper.MapManyToDto(entity.GamePromotions) as List<GamePromotionDto>;

            studioPromos.ToList().ForEach(sp => dto.GamePromotions.Add(sp));

            return dto;
        }

        public async Task<IEnumerable<CatalogueGameDto>> MapManyToCatalogueGame(IEnumerable<Game> entities)
        {
            var dtos = new List<CatalogueGameDto>();

            foreach (var entity in entities) { dtos.Add(await MapToCatalogueGame(entity)); }

            return dtos;
        }

        private async Task<IEnumerable<GamePromotionDto>> GetStudioPromotions(Game entity)
        {
            var studios = entity.GameStudios.Select(e => e.Studio);

            return await _promotionsMapper.MapManyToDto(studios.SelectMany(s => s.GamePromotions));
        }
    }
}
