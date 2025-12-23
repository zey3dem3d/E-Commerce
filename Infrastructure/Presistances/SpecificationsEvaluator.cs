using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistences
{
    internal static class SpecificationsEvaluator
    {
        public static IQueryable<TEntity> GetQuery<TEntity, TKey>(IQueryable<TEntity> inputQuery, ISpecifications<TEntity, TKey> specifications)
            where TEntity : BaseEntity<TKey>
        {
            var query = inputQuery;

            if (specifications.Criteria is not null)
                query = query.Where(specifications.Criteria);

            if (specifications.IncludeExpressions?.Count > 0)
                query = specifications.IncludeExpressions.Aggregate(query, (CurrentQuery, IncludeExpression) => CurrentQuery.Include(IncludeExpression));

            if(specifications.OrderBy is not null)
                query = query.OrderBy(specifications.OrderBy);

            if(specifications.OrderByDescending is not null)
                query = query.OrderByDescending(specifications.OrderByDescending);

            return query;
        }
    }
}
