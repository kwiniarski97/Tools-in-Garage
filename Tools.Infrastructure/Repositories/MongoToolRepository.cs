using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<Tool> GetAsync(string model) =>
            await Tools.AsQueryable().FirstOrDefaultAsync(tool => tool.Model == model);


        public async Task<Tool> GetAsync(Guid id) =>
            await Tools.AsQueryable().FirstOrDefaultAsync(tool => tool.Id == id);

        public async Task<IEnumerable<Tool>> GetAllAsync() =>
            await Tools.AsQueryable().ToListAsync();

        public async Task AddAsync(Tool tool) =>
            await Tools.InsertOneAsync(tool);

        public async Task DeleteAsync(Guid id)
        {
            var tool = await GetAsync(id);
            //had to do it this way cause short on time
            await Tools.DeleteOneAsync( x => x.Box == tool.Box && x.Brand == tool.Brand 
                                                && x.Model == tool.Model);
        }

        public async Task UpdateAsync(Tool tool)
        {
            var toolOriginal = await GetAsync(tool.Id);
            
            await Tools.ReplaceOneAsync(x => x.Box == toolOriginal.Box && x.Brand == toolOriginal.Brand 
                                             && x.Model == toolOriginal.Model, tool);
        }
            


        private IMongoCollection<Tool> Tools => _database.GetCollection<Tool>("Tools");
    }
}