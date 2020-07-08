using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.EntitiesCF;

namespace Domain.Contracts.Mappers
{
    public interface IGamesMapperService : IMapperService<Game, GameDetailDto>
    {
        Task<CatalogueGameDto> MapToCatalogueGame(Game entity);
        Task<IEnumerable<CatalogueGameDto>> MapManyToCatalogueGame(IEnumerable<Game> entities);
    }
}
