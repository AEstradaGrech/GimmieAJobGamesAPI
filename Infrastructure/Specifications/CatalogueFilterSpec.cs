using System;
using System.Linq.Expressions;
using Domain.EntitiesCF;
using Domain.Enums;
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
            var priceSpec = GetPriceSpec();
            var dateSpec = GetDateSpec();

            return (pegiSpec &
                    titleSpec &
                    genreSpec &
                    priceSpec &
                    dateSpec).SatisfiedBy();
        }

        private Specification<Game> GetPegiSpec()
        {
            if (_filter.PEGI != null)
                return new GamePegiSpec((PEGI)_filter.PEGI, _filter.IsGreaterThanPEGI);

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
            {
                var genres = _filter.Genre.Split('/');

                return new GameGenreSpec(genres);
            }
                
            return new TrueSpecification<Game>();
        }

        private Specification<Game> GetPriceSpec()
        {
            if (_filter.Price != null)
                return new GamePriceSpec(_filter.IsGreaterThanPrice, (int)_filter.Price);

            return new TrueSpecification<Game>();
        }

        private Specification<Game> GetDateSpec()
        {            
            return new GameReleaseDateSpec(_filter.MinReleaseDate, _filter.MaxReleaseDate);            
        }
    }
}
