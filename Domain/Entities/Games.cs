using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Games
    {
        public Games()
        {
            GamePromotion = new HashSet<GamePromotion>();
            StudioGame = new HashSet<StudioGame>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Platform { get; set; }
        public int Players { get; set; }
        public bool IsOnline { get; set; }
        public int Pegi { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public decimal? Price { get; set; }
        public int? AvailableZone { get; set; }

        public virtual ICollection<GamePromotion> GamePromotion { get; set; }
        public virtual ICollection<StudioGame> StudioGame { get; set; }
    }
}
