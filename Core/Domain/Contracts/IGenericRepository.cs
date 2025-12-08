using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        // Get All
        Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking = false);
        // Get By Id
        Task<TEntity?> GetByIdAsync(TKey id);
        // Create
        Task AddAsync(TEntity entity);
        // Update
        void Update(TEntity entity);
        // Delete
        void Delete(TEntity entity);
    }
}
