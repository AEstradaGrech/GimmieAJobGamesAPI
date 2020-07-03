using System;
using System.Linq.Expressions;
using Domain.EntitiesCF;
using Domain.Filters;

namespace Infrastructure.Specifications
{
    public class CatalogueFilterSpec : Specification<Game> 
    {
        private readonly CatalogueFilter _filter;

        public CatalogueFilterSpec(CatalogueFilter filter)
        {
            _filter = filter;
        }

        public override Expression<Func<Game, bool>> SatisfiedBy()
        {
            var pegiSpec = GetPegiSpec();
            var titleSpec = GetTitleSpec();
            var genreSpec = GetGenreSpec();

            return (pegiSpec &
                    titleSpec &
                    genreSpec).SatisfiedBy();
        }

        private Specification<Game> GetPegiSpec()
        {
            if (_filter.PEGI != null)
                return new Specification<Game>(g => g.PEGI == _filter.PEGI);

            return new TrueSpecification<Game>();
        }
        private Specification<Game> GetTitleSpec()
        {
            if (!string.IsNullOrEmpty(_filter.Title))
                return new Specification<Game>(g => g.Title == _filter.Title);

            return new TrueSpecification<Game>();
        }
    
        private Specification<Game> GetGenreSpec()
        {
            if (!string.IsNullOrEmpty(_filter.Genre))
                return new Specification<Game>(g => g.Genre == _filter.Genre);

            return new TrueSpecification<Game>();
        }
    }
}
