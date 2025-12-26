using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    internal abstract class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        #region Criteria
        protected BaseSpecifications(Expression<Func<TEntity, bool>>? criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<TEntity, bool>>? Criteria { get; private set; }
        #endregion

        #region Include Expression
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = new();

        protected void AddIncludes(Expression<Func<TEntity, object>> inculdeExpressions)
        {
            IncludeExpressions.Add(inculdeExpressions);
        }
        #endregion

        #region Sorting OrderBy, OrderByDescending
        public Expression<Func<TEntity, object>>? OrderBy { get; private set; }
        protected void SetOrderBy(Expression<Func<TEntity, Object>> orderByExpression)
           => OrderBy = orderByExpression;

        public Expression<Func<TEntity, object>>? OrderByDescending { get; private set; }
        protected void SetOrderByDescending(Expression<Func<TEntity, Object>> orderByDescendingExpression)
           => OrderByDescending = orderByDescendingExpression;
        #endregion

        #region Pagination
        public int Skip { get; private set; }
        public int Take { get; private set; }
        public bool IsPaginated { get; private set; }

        protected void ApplyPagination(int pageIndex, int pageSize)
        {
            IsPaginated = true;
            Take = pageSize;
            Skip = (pageIndex - 1) * pageSize;
        }
        #endregion
    }
}
