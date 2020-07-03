using System;
using System.Linq.Expressions;
using Domain.EntitiesCF;

namespace Infrastructure.Specifications
{
    public class TrueSpecification<T> : Specification<T> where T : Entity
    {
        public TrueSpecification() : base(x => true)
        {
        }

        
    }
}
