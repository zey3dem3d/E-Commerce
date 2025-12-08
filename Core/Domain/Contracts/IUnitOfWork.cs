using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IUnitOfWork
    {
        // CompleteAsync (SaveChangesAsync())
        public Task<int> SaveChangesAsync();

        // Signature For Method Will Return An Object From Class That Implements IGenericRepository
        IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;

    }
}
