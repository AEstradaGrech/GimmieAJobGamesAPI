using System;
using System.Collections.Generic;

namespace Domain.EntitiesCF
{
    public class Game : Entity
    {
        public string Title { get; set; }
        public string Genre { get; set; }        
        public int PEGI { get; set; }
        public decimal? Price { get; set; }
        public ICollection<GameStudio> GameStudios { get; set; }
        public ICollection<GamePromotion> GamePromotions { get; set; }
    }
}
