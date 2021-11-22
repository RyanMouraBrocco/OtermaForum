using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using OtermaForum.Infra.NoSql.Attributes;
using OtermaForum.Infra.NoSql.Dtos.Base;
using OtermaForum.Infra.NoSql.Interfaces;
using OtermaForum.Infra.NoSql.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaForum.Infra.NoSql.Repositories
{
    public class MongoRepository<TDto> : IMongoRepository<TDto> where TDto : BaseDto
    {
        private readonly IMongoCollection<TDto> _collection;

        public MongoRepository(IOptions<MongoDbSettings> options)
        {
            MongoClient client = new MongoClient(options.Value.ConnectionString);
            IMongoDatabase database = client.GetDatabase(options.Value.DataBaseName);
            _collection = database.GetCollection<TDto>(GetCollectionName());
        }

        private string GetCollectionName()
        {
            return ((MongoCollectionAttribute)typeof(TDto).GetCustomAttributes(typeof(MongoCollectionAttribute), true).First()).CollectionName;
        }

        public async Task<TDto> InsertAsync(TDto value)
        {
            await _collection.InsertOneAsync(value);
            return value;
        }

        public async Task<TDto> UpdateAsync(ObjectId id, TDto value)
        {
            var filterById = Builders<TDto>.Filter.Eq(x => x.Id, id);
            await _collection.ReplaceOneAsync(filterById, value);
            return value;
        }

        public async Task<TDto> GetOneByIdAsync(string id)
        {
            return (await _collection.FindAsync(x => x.Id == new ObjectId(id))).FirstOrDefault();
        }

        public IQueryable<TDto> GetAll()
        {
            return _collection.AsQueryable();
        }
    }
}
