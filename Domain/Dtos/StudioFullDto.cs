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
        
        public List<GamePromotionDto> StudioGamePromotions { get; set; }
    }
}
