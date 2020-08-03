using System;
namespace Domain.EntitiesCF
{
    public class GameDescription : Entity
    {
        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public string Description { get; set; }
        public string GameTitle { get; set; }
    }
}
