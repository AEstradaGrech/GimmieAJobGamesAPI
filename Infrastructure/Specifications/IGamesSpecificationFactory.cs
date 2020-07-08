using System;
using System.Threading.Tasks;
using Domain.Filters;

namespace Infrastructure.Specifications
{
    public interface IGamesSpecificationFactory
    {
        Task<CatalogueFilterSpec> GetCatalogueFilterSpec(CatalogueFilter filter);
    }
}
