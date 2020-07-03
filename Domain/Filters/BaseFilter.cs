using System;
using System.Collections.Generic;
using Domain.Enums;

namespace Domain.Filters
{
    public class BaseFilter
    {
        public string Title { get; set; }
        public string Studio { get; set; }
        public List<int> SortingParams { get; set; }
        public PEGI? PEGI { get; set; }
        public string Genre { get; set; }
        public bool IsOrderByDescending { get; set; }
        public int ChunkSize { get; set; }
        public int Skip { get; set; }
    }
}
