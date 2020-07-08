using System;
using System.Linq.Expressions;
using Domain.EntitiesCF;
using Domain.Enums;

namespace Infrastructure.Specifications
{
    public class GamePegiSpec : Specification<Game>
    {
        private readonly PEGI _PEGI;
        private readonly bool _isGreaterThanPEGI;

        public GamePegiSpec(PEGI PEGI, bool isGraterThanPEGI = true)
        {
            _PEGI = PEGI;
            _isGreaterThanPEGI = isGraterThanPEGI;
            Predicate = SetPredicate();
        }

        private Expression<Func<Game,bool>> SetPredicate()
        {           
            switch (_isGreaterThanPEGI)
            {
                case (true):
                    return g => g.PEGI >= _PEGI;
                case (false):
                    return (g => g.PEGI <= _PEGI);
                default:
                    return g => g.PEGI >= _PEGI;
            }                     
        }
    }
}
