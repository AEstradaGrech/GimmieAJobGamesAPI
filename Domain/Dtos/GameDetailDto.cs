using System;
using System.Collections.Generic;
using Domain.EntitiesCF;

namespace Domain.Dtos
{
    public class GameDetailDto : CatalogueGameDto        
    {
        public GameDetailDto()
        {
            GameStudios = new List<StudioDto>();
        }

        public int Players { get; set; }
        public bool IsOnline { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public List<StudioDto> GameStudios { get; set; }
        public string Description { get; set; }
    }
}
