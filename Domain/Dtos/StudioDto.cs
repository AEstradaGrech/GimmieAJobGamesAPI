using System;
using System.Collections.Generic;

namespace Domain.Dtos
{
    public class StudioDto
    {
        public StudioDto()
        {
            StudioGames = new List<CatalogueGameDto>();
        }

        public string StudioName { get; set; }
        public DateTime Established { get; set; }
        public ICollection<CatalogueGameDto> StudioGames { get; set; }
    }
}
