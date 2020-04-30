using System;
using System.Collections.Generic;

namespace GimmieAJobGamesAPI.Context
{
    public partial class Promotions
    {
        public Promotions()
        {
            GamePromotion = new HashSet<GamePromotion>();
        }

        public int Id { get; set; }
        public string PromoDesc { get; set; }
        public int Discount { get; set; }
        public bool? IsValid { get; set; }

        public virtual ICollection<GamePromotion> GamePromotion { get; set; }
    }
}
