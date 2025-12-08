using Domain.Contracts;
using Domain.Entities;
using Presistences.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _dbContext;

        private readonly ConcurrentDictionary<string, object> _repositories;

        public UnitOfWork(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new();
        }

        public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
            => (IGenericRepository<TEntity, TKey>)_repositories.GetOrAdd(typeof(TEntity).Name, (_) => new GenericRepository<TEntity, TKey>(_dbContext));
        // return new GenericRepository<TEntity, TKey>(_dbContext);
        // Dictionary
        // Key ---> NameOf Entity [Product, ProdcutBrand, ProductType] ---> String
        // Value ---> Object Of Generic Repository
        // Product ---> new GenericRepository<Product, int>

        //var Key = typeof(TEntity).Name;

        //if (!_repositories.ContainsKey(Key))
        //    _repositories[Key] = new GenericRepository<TEntity, TKey>(_dbContext);
        //return (IGenericRepository<TEntity, TKey>)_repositories[Key];
    }
}
