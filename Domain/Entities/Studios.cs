using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Studios
    {
        public Studios()
        {
            GamePromotion = new HashSet<GamePromotion>();
            StudioGame = new HashSet<StudioGame>();
        }

        public int Id { get; set; }
        public string StudioName { get; set; }
        public DateTime Established { get; set; }

        public virtual ICollection<GamePromotion> GamePromotion { get; set; }
        public virtual ICollection<StudioGame> StudioGame { get; set; }
    }
}
