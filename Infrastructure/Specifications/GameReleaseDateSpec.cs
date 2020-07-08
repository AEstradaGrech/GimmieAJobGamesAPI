using System;
using System.Linq.Expressions;
using Domain.EntitiesCF;

namespace Infrastructure.Specifications
{
    public class GameReleaseDateSpec : Specification<Game>
    {
        private DateTime? _minDate;
        private DateTime? _maxDate;

        public GameReleaseDateSpec(DateTime? minDate, DateTime? maxDate)
        {
            _minDate = minDate;
            _maxDate = maxDate;
            Predicate = SetPredicate();
        }

        private Expression<Func<Game,bool>> SetPredicate()
        {
            
            var maxDate = _maxDate != null ?
                          new Specification<Game>(g => g.ReleaseDate <= _maxDate) :
                          new TrueSpecification<Game>();
            var minDate = _minDate != null ?
                          new Specification<Game>(g => g.ReleaseDate >= _minDate) :
                          new TrueSpecification<Game>();

            return (maxDate & minDate).SatisfiedBy();
        }
    }
}
