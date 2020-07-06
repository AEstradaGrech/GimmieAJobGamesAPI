using System;
using System.Linq;
using System.Linq.Expressions;
using Domain.EntitiesCF;

namespace Infrastructure.Specifications
{
    public class Specification<T> : ISpecification<T> where T : Entity
    {
        private Expression<Func<T, bool>> _predicate;
        public Expression<Func<T, bool>> Predicate { get => _predicate; set => _predicate = value; }

        public Specification() { }

        public Specification(Expression<Func<T, bool>> expression)
        {
            _predicate = expression;
        }
       
        public virtual Expression<Func<T,bool>> SatisfiedBy()
        {
            return _predicate;
        }

        public static Specification<T> operator &(Specification<T> leftHand, Specification<T> rightHand)
        {
            InvocationExpression rightInvoke = Expression.Invoke(rightHand.Predicate, leftHand.Predicate.Parameters.Cast<Expression>());

            BinaryExpression newExpression = Expression.MakeBinary(ExpressionType.AndAlso, leftHand.Predicate.Body, rightInvoke);

            return new Specification<T>(Expression.Lambda<Func<T, bool>>(newExpression, leftHand.Predicate.Parameters));
        }

        public static Specification<T> operator |(Specification<T> leftHand, Specification<T> rightHand)
        {
            InvocationExpression rightInvoke = Expression.Invoke(rightHand.Predicate, leftHand.Predicate.Parameters.Cast<Expression>());

            BinaryExpression newExpression = Expression.MakeBinary(ExpressionType.Or, leftHand.Predicate.Body, rightInvoke);

            return new Specification<T>(Expression.Lambda<Func<T, bool>>(newExpression, leftHand.Predicate.Parameters));
        }
    }
}
