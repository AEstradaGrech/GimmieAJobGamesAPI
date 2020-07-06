using System;
using System.Linq.Expressions;
using Domain.EntitiesCF;

namespace Infrastructure.Helpers
{
    public abstract class BaseSortingParameterFactory<T> : IBaseSortingParamExpressionFactory<T> where T : Entity
    {
        public abstract Expression<Func<T,object>> GetSortingParamExpresion(int sortingParam);                  
    }
}
