using System;
using System.Threading.Tasks;
using Domain.EntitiesCF;

namespace Domain.Contracts.Mappers
{
    public interface IMapperService<TEntity, TDto> where TEntity : Entity
    {
        Task<TDto> MapToDto(TEntity entity);
        Task<TEntity> MapToEntity(TDto dto);
    }
}
