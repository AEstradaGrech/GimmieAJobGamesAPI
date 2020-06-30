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
    public class StudiosMapperService : IStudiosMapperService
    {
        
        

        public StudiosMapperService()
        {
            
            
        }

        public async Task<IEnumerable<StudioDto>> MapManyToDto(IEnumerable<Studio> entities)
        {
            var dtos = new List<StudioDto>();

            foreach(var e in entities) { dtos.Add(await MapToDto(e)); }

            return dtos;
        }

        public Task<IEnumerable<Studio>> MapManyToEntity(IEnumerable<StudioDto> dtos)
        {
            throw new NotImplementedException();
        }

        public async Task<StudioDto> MapToDto(Studio entity)
        {
            var dto = new StudioDto();

            return (StudioDto)dto.InjectFrom(entity);
        }

        public Task<Studio> MapToEntity(StudioDto dto)
        {
            throw new NotImplementedException();
        }

        
    }
}
