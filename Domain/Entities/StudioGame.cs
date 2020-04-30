using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class StudioGame
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int StudioId { get; set; }

        public virtual Games Game { get; set; }
        public virtual Studios Studio { get; set; }
    }
}
