using System;
using System.Linq.Expressions;
using Domain.EntitiesCF;

namespace Infrastructure.Specifications
{
    public interface ISpecification<T> where T : Entity
    {
        Expression<Func<T, bool>> Predicate { get; }
        Expression<Func<T, bool>> SatisfiedBy();
    }
}
