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

            var dtoStudios = entity.GameStudios.Select(e => e.Studio);            

            var studioPromos = await _promotionsMapper.MapManyToDto(dtoStudios.SelectMany(s => s.GamePromotions));

            dto.GameStudios = await _studiosMapper.MapManyToDto(dtoStudios) as ICollection<StudioDto>;

            dto.GamePromotions = await _promotionsMapper.MapManyToDto(entity.GamePromotions) as ICollection<GamePromotionDto>;

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

            return (CatalogueGameDto)dto.InjectFrom(entity);
        }

        public async Task<IEnumerable<CatalogueGameDto>> MapManyToCatalogueGame(IEnumerable<Game> entities)
        {
            var dtos = new List<CatalogueGameDto>();

            foreach (var entity in entities) { dtos.Add(await MapToCatalogueGame(entity)); }

            return dtos;
        }
    }
}
