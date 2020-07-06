using System;
using System.Linq.Expressions;
using Domain.EntitiesCF;

namespace Infrastructure.Specifications
{
    public class GamePriceSpec : Specification<Game>
    {
        private int _price; 
        private bool _isGreaterThanPrice;

        public GamePriceSpec(bool isGreaterThanPrice, int price)
        {
            _price = price;
            _isGreaterThanPrice = isGreaterThanPrice;
            Predicate = SetPredicate();
        }

        private Expression<Func<Game,bool>> SetPredicate()
        {
            switch (_isGreaterThanPrice)
            {
                case (true):
                    return x => x.Price >= _price;
                case (false):
                    return x => x.Price <= _price;
                default:
                    return x => x.Price <= _price;
            }
            
        }
    }
}
