using System;
using System.Collections.Generic;
using Domain.Dtos;

namespace Domain.Filters
{
    public class CatalogueResponseDto
    {
        public CatalogueResponseDto()
        {
            Games = new List<CatalogueGameDto>();
        }

        public List<CatalogueGameDto> Games { get; set; }
        public int TotalCount { get; set; }
    }
}
