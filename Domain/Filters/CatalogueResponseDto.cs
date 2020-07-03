using System;
using System.Collections.Generic;
using Domain.Dtos;

namespace Domain.Filters
{
    public class CatalogueResponseDto
    {
        public CatalogueResponseDto()
        {
            Games = new List<GameDetailDto>();
        }

        public IEnumerable<CatalogueGameDto> Games { get; set; }
        public int TotalCount { get; set; }
    }
}
