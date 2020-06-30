using System;
using System.Collections.Generic;
using Domain.EntitiesCF;
using Domain.Enums;

namespace Domain.Dtos
{
    public class CatalogueGameDto
    {
        public CatalogueGameDto()
        {
            GamePromotions = new List<GamePromotionDto>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }        
        public string Genre { get; set; }
        public decimal? Price { get; set; }        
        public PEGI PEGI { get; set; }
        public ICollection<GamePromotionDto> GamePromotions { get; set; }

    }
}
