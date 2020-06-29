using System;
using System.Collections.Generic;
using Domain.EntitiesCF;

namespace Domain.Dtos
{
    public class CatalogueGameDto
    {
        public CatalogueGameDto()
        {
            GamePromotions = new List<GamePromotion>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }        
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public string Promotion { get; set; }
        public int PEGI { get; set; }
        public ICollection<GamePromotion> GamePromotions { get; set; }

    }
}
