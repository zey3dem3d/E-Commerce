using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public Expression<Func<TEntity, bool>>? Criteria { get; } // P => P.Id
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } // P => P.ProductBrand, P => P.ProductType
        public Expression<Func<TEntity, Object>>? OrderBy { get; }
        public Expression<Func<TEntity, Object>>? OrderByDescending { get; }
        public int Skip { get; }
        public int Take { get; }
        public bool IsPaginated { get; }
    }
}
