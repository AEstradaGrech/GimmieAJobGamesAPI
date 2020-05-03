using System;
namespace Domain.EntitiesCF
{
    public class Promotion : Entity
    {
        public string Description { get; set; }
        public int? Discount { get; set; }

    }
}
