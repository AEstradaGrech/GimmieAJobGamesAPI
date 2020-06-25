using System;
using System.Collections.Generic;

namespace Domain.EntitiesCF
{
    public class Promotion : Entity
    {
        public string Description { get; set; }
        public int? Discount { get; set; }
        public ICollection<GamePromotion> GamePromotion { get; set; }

    }
}
