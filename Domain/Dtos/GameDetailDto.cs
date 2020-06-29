using System;
using System.Collections.Generic;
using Domain.EntitiesCF;

namespace Domain.Dtos
{
    public class GameDetailDto : CatalogueGameDto        
    {
        public GameDetailDto()
        {
            GameStudios = new List<GameStudio>();
        }

        public int Players { get; set; }
        public bool IsOnline { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public ICollection<GameStudio> GameStudios { get; set; }
    }
}
