using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shared;
using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public abstract class MongoBaseRepository<TModel> : IRepository<TModel, Guid>
        where TModel : IEntitiy<Guid>
    {
        private readonly MongoDatabaseSettings _mongoDbSettings;
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _database;

        public MongoBaseRepository(IOptions<MongoDatabaseSettings> mongoDbSettings)
        {
            _mongoDbSettings = mongoDbSettings.Value;
            _mongoClient = new MongoClient(_mongoDbSettings.ConnectionString);
            _database = _mongoClient.GetDatabase(_mongoDbSettings.DatabaseName);
        }

        public virtual Task AddAsync(TModel obj, CancellationToken cancellationToken = default)
        {
            return GetCollection().InsertOneAsync(obj, cancellationToken = default);
        }

        public virtual async Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await GetCollection().Find(Builders<TModel>.Filter.Empty).ToListAsync(cancellationToken);
        }

        public virtual Task<TModel> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return GetCollection().Find(Builders<TModel>.Filter.Eq("_id", id)).FirstAsync(cancellationToken);
        }

        public virtual Task UpdateAsync(Guid id, TModel obj, CancellationToken cancellationToken = default)
        {
            return GetCollection().ReplaceOneAsync(Builders<TModel>.Filter.Eq("_id", id), obj, new ReplaceOptions() { IsUpsert = false }, cancellationToken);
        }

        public virtual Task RemoveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return GetCollection().DeleteOneAsync(Builders<TModel>.Filter.Eq("_id", id), cancellationToken);
        }


        private IMongoCollection<TModel> GetCollection()
        {
            return _database.GetCollection<TModel>(nameof(TModel));
        }
    }
}
