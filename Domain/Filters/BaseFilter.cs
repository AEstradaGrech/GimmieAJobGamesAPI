using System;
using System.Collections.Generic;

namespace Domain.Filters
{
    public class BaseFilter
    {
        public string Title { get; set; }
        public string Studio { get; set; }
        public List<int> SortingParams { get; set; }
        public int PEGI { get; set; }
        public string Genre { get; set; }
    }
}
