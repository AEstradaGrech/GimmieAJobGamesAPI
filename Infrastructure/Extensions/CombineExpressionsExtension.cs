using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Extensions
{
    public static class CombineExpressionsExtension 
    {
       public static Expression<Func<T,bool>> CombinePredicates<T>(this Expression<Func<T,bool>> expression,
           List<Expression<Func<T,bool>>>predicates, Func<Expression, Expression, BinaryExpression>logicalExpression)
           where T : class
       {
            if(predicates.Count > 0)
            {
                Expression body = predicates.First().Body;

                for (int i = 0; i < predicates.Count; i++)
                {
                    body = logicalExpression(body, Expression.Invoke(predicates[i], predicates[0].Parameters));
                }

                expression = Expression.Lambda<Func<T, bool>>(body, predicates[0].Parameters);
            }                        

            return expression;
       }
    }
}
