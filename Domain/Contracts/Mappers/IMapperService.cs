using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.EntitiesCF;

namespace Domain.Contracts.Mappers
{
    public interface IMapperService<TEntity, TDto> where TEntity : Entity
    {
        Task<TDto> MapToDto(TEntity entity);
        Task<TEntity> MapToEntity(TDto dto);
        Task<IEnumerable<TEntity>> MapManyToEntity(IEnumerable<TDto> dtos);
        Task<IEnumerable<TDto>> MapManyToDto(IEnumerable<TEntity> entities);
    }
}
