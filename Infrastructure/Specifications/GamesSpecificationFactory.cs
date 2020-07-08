using System;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Filters;

namespace Infrastructure.Specifications
{
    public class GamesSpecificationFactory : IGamesSpecificationFactory
    {     
        public async Task<CatalogueFilterSpec> GetCatalogueFilterSpec(CatalogueFilter filter)
        {
            return new CatalogueFilterSpec(filter);
        }
    }
}
