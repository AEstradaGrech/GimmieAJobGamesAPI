using System;
using System.Linq.Expressions;
using Domain.EntitiesCF;
using Domain.Enums;

namespace Infrastructure.Helpers
{
    public class StudioSortingParamExpressionFactory : BaseSortingParameterFactory<Studio>, IStudioSortingParamExpressionFactory
    {   
        public override Expression<Func<Studio, object>> GetSortingParamExpresion(int sortingParam)
        {
            switch (sortingParam)
            {
                case ((int)StudioSortingParam.StudioName):
                    return x => x.StudioName;
                case ((int)StudioSortingParam.Established):
                    return x => x.Established;
                default:
                    return x => x.StudioName;
            }
        }
    }
}
