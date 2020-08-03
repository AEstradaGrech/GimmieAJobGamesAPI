using System;
using System.Collections.Generic;
using Domain.Enums;

namespace Domain.EntitiesCF
{
    public class Game : Entity
    {
        public Game()
        {
            GameStudios = new List<GameStudio>();
            GamePromotions = new List<GamePromotion>();
        }

        public string Title { get; set; }
        public string Genre { get; set; }        
        public PEGI PEGI { get; set; }
        public int Players { get; set; }
        public bool IsOnline { get; set; }
        public DateTime? ReleaseDate { get; set; }        
        public decimal? Price { get; set; }
        public ICollection<GameStudio> GameStudios { get; set; }
        public ICollection<GamePromotion> GamePromotions { get; set; }
        public GameDescription GameDescription { get; set; }
    }
}
