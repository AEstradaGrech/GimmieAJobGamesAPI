using System;
using System.Linq.Expressions;
using Domain.EntitiesCF;
using Domain.Enums;

namespace Infrastructure.Helpers
{
    public class GameSortingParamExpressionFactory : BaseSortingParameterFactory<Game>, IGameSortingParamExpressionFactory
    {
        public override Expression<Func<Game, object>> GetSortingParamExpresion(int sortingParam)
        {
            switch(sortingParam)
            {
                case ((int)GameSortingParam.Title):
                    return x => x.Title;
                case ((int)GameSortingParam.Price):
                    return x => x.Price;
                case ((int)GameSortingParam.ReleaseDate):
                    return x => x.ReleaseDate;
                case ((int)GameSortingParam.PEGI):
                    return x => x.PEGI;
                default:
                    return x => x.Title;
            }
        }
    }
}
