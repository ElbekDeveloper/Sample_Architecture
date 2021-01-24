using Shared;
using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MongoRepository : IRepository<Guid>
    {
        public Task<T> AddAsync<T>(T entity) where T : BaseEntity<Guid>, IAggregateRoot
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync<T>(T entity) where T : BaseEntity<Guid>, IAggregateRoot
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll<T>() where T : BaseEntity<Guid>, IAggregateRoot
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync<T>(Guid id) where T : BaseEntity<Guid>, IAggregateRoot
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync<T>(T entity) where T : BaseEntity<Guid>, IAggregateRoot
        {
            throw new NotImplementedException();
        }
    }
}
