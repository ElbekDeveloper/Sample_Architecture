using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    /// <summary>
    /// Declares the contract for CRUD operations
    /// for entities
    /// </summary>
    /// <typeparam name="TId">Id depending the database type</typeparam>
    public interface IRepository<TModel, TId> where TModel : IEntitiy<TId>
    {
        Task AddAsync(TModel obj, CancellationToken cancellationToken);
        Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<TModel> GetByIdAsync(TId id, CancellationToken cancellationToken);
        Task UpdateAsync(TId id, TModel obj, CancellationToken cancellationToken);
        Task RemoveAsync(TId id, CancellationToken cancellationToken);
    }
}
