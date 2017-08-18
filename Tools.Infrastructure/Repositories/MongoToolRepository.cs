using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Tools.Core.Domain;
using Tools.Core.Repositories;

namespace Tools.Infrastructure.Repositories
{
    public class MongoToolRepository : IToolRepository
    {
        private readonly IMongoDatabase _database;

        public MongoToolRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<Tool> GetAsyncId(string model) =>
            await Tools.AsQueryable().FirstOrDefaultAsync(tool => tool.Model == model);

        public async Task<IEnumerable<Tool>> GetAllAsync() =>
            await Tools.AsQueryable().ToListAsync();

        public async Task AddAsync(Tool tool) =>
            await Tools.InsertOneAsync(tool);

        public async Task DeleteAsync(Guid id)
        {
            await Tools.DeleteOneAsync(x => x.Id == new Guid(id.ToString()));
        }

        public async Task UpdateAsync(Tool tool)
        {
            await Tools.ReplaceOneAsync(x => x.Id == new Guid(tool.Id.ToString()),tool);
        }

        public async Task<Tool> GetAsyncId(Guid id) =>
            await Tools.AsQueryable().FirstOrDefaultAsync(tool => tool.Id == new Guid(id.ToString()));

        private IMongoCollection<Tool> Tools => _database.GetCollection<Tool>("Tools");
        }
}