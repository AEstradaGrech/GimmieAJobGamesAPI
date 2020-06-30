using System;
using System.Collections.Generic;

namespace Domain.Dtos
{
    public class StudioFullDto : StudioDto
    {
        public StudioFullDto()
        {
            StudioGames = new List<CatalogueGameDto>();
            StudioGamePromotions = new List<GamePromotionDto>();
        }

        public ICollection<CatalogueGameDto> StudioGames { get; set; }
        public ICollection<GamePromotionDto> StudioGamePromotions { get; set; }
    }
}
