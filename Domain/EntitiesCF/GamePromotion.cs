using System;
namespace Domain.EntitiesCF
{
    public class GamePromotion : Entity
    {
        public Promotion Promotion { get; set; }
        public Studio? Studio { get; set; }
        public Game? Game { get; set; }
        public AccountType AccountType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
