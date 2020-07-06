using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.EntitiesCF;
using Infrastructure.Extensions;

namespace Infrastructure.Specifications
{
    public class GameGenreSpec : Specification<Game>
    {
        private IEnumerable<string> _gameGenres;

        public GameGenreSpec(IEnumerable<string> gameGenres)
        {
            _gameGenres = gameGenres;
            Predicate = SetPredicate();
        }

        public Expression<Func<Game,bool>> SetPredicate()
        {
            Expression<Func<Game,bool>> finalExpression = null;

            List<Expression<Func<Game, bool>>> predicates = new List<Expression<Func<Game, bool>>>();

            _gameGenres.ToList().ForEach(genre => {

                Expression<Func<Game, bool>> predicate = g => g.Genre.Contains(genre);

                predicates.Add(predicate);
            });

            return finalExpression.CombinePredicates(predicates, Expression.Or);

        }
    }
}
