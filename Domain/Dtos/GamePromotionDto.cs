using System;
using Domain.EntitiesCF;

namespace Domain.Dtos
{
    public class GamePromotionDto
    {    
        public string Description { get; set; }
        public int? Discount { get; set; } 
        public AccountTypes? AccountType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }                
    }
}
