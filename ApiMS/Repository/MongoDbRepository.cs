using ApiMS.Interface;
using ApiMS.Model;
using ApiMS.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiMS.Repository
{
    public abstract class MongoDbRepository<T> : IMongoDbRepository<T> where T : Entity, new()
    {
        private readonly IMongoCollection<T> _collection;

        public MongoDbRepository(IOptions<StoreDatabaseSettings> storeDatabaseSettings)
        {
            var mongoClient = new MongoClient(storeDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(storeDatabaseSettings.Value.DatabaseName);
            _collection = mongoDatabase.GetCollection<T>(Collections.GetCollections(new T()));
        }

        public async Task CreateAsync(T entity)
        {
           await _collection.InsertOneAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(a => a.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(a => a.Id.Equals(id));
        }

        public async Task UpdateAsync(string id, T entity)
        {
            await _collection.ReplaceOneAsync(a => a.Id.Equals(id), entity);
        }
    }
}
