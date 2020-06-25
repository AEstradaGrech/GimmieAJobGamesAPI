using System;
namespace Domain.EntitiesCF
{
    public class GamePromotion : Entity
    {
        public Promotion Promotion { get; set; }
        public Guid? StudioId { get; set; }
        public Studio Studio { get; set; }
        public Guid? GameId { get; set; }
        public Game Game { get; set; }
        public AccountTypes? AccountType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
