using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IRepository<TId>
    {
        Task<T> GetByIdAsync<T>(TId id) where T : BaseEntity<TId>, IAggregateRoot;
        Task<List<T>> GetAll<T>() where T : BaseEntity<TId>, IAggregateRoot;
        Task<T> AddAsync<T>(T entity) where T : BaseEntity<TId>, IAggregateRoot;
        Task UpdateAsync<T>(T entity) where T : BaseEntity<TId>, IAggregateRoot;
        Task DeleteAsync<T>(T entity) where T : BaseEntity<TId>, IAggregateRoot;
    }
}
