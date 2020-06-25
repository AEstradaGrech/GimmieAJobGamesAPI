using System;
namespace Domain.EntitiesCF
{
    public class GameStudio : Entity
    {
        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public Guid StudioId { get; set; }
        public Studio Studio { get; set; }
    }
}
