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

        public async Task<IEnumerable<Tool>> GetAllOfTypeAsync(string type) =>
        //todo tutaj trzeba to jakos zaimplementowac
//            await from tool in Tools.AsQueryable() where tool.Type == type select tool;
            await Tools.AsQueryable().ToListAsync();

        public async Task AddAsync(Tool tool) =>
            await Tools.InsertOneAsync(tool);


        public async Task DeleteAsync(Guid id) =>
            await Tools.DeleteOneAsync(tool => tool.Id == id);

        public async Task UpdateAsync(Tool tool) =>
            await Tools.ReplaceOneAsync(x => x.Id == tool.Id, tool);
        

        private IMongoCollection<Tool> Tools => _database.GetCollection<Tool>("Tools");
    }
}