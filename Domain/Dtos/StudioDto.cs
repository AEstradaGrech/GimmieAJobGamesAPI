using System;
using System.Collections.Generic;

namespace Domain.Dtos
{
    public class StudioDto
    {
        public StudioDto()
        {
            StudioGames = new List<CatalogueGameDto>();
            StudioGamePromotions = new List<GamePromotionDto>();
        }

        public string StudioName { get; set; }
        public DateTime Established { get; set; }
        public ICollection<CatalogueGameDto> StudioGames { get; set; }
        public ICollection<GamePromotionDto> StudioGamePromotions { get; set; }
    }
}
