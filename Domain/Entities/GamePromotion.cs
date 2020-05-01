using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class GamePromotion
    {
        public int Id { get; set; }
        public int? GameId { get; set; }
        public int PromotionId { get; set; }
        public int? StudioId { get; set; }
        public int? AccountTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual AccountType AccountType { get; set; }
        public virtual Games Game { get; set; }
        public virtual Promotions Promotion { get; set; }
        public virtual Studios Studio { get; set; }
    }
}
