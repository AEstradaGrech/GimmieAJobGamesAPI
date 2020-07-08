using System;
using System.Linq.Expressions;
using Domain.EntitiesCF;

namespace Infrastructure.Helpers
{
    public interface IBaseSortingParamExpressionFactory<T> where T : Entity
    {
        Expression<Func<T, object>> GetSortingParamExpresion(int sortingParam);
    }
}
