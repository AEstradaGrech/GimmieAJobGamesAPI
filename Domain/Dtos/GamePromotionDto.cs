using System;
using Domain.EntitiesCF;

namespace Domain.Dtos
{
    public class GamePromotionDto
    {
        public GamePromotionDto()
        {
        }

        public string Description { get; set; } // FROM Promotion
        public int? Discount { get; set; } // FROM Promotion
        public AccountTypes? AccountType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CatalogueGameDto PromotedGame { get; set; }
        public StudioDto PromotedStudio { get; set; }
    }
}
