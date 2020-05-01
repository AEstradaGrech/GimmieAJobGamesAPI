using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Queries
    {
        public int Id { get; set; }
        public string QueryName { get; set; }
        public string Query { get; set; }
    }
}
