﻿using System;
using System.Collections.Generic;

namespace Domain.EntitiesCF
{
    public class Studio : Entity
    {
        public Studio()
        {
            StudioGames = new List<GameStudio>();
            GamePromotions = new List<GamePromotion>();
        }

        public string StudioName { get; set; }
        public DateTime Established { get; set; }
        public ICollection<GameStudio> StudioGames { get; set; }
        public ICollection<GamePromotion> GamePromotions { get; set; }
    }
}
