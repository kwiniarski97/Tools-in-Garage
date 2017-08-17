using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
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

        public async Task<Tool> GetAsyncId(string model) =>
            await Tools.AsQueryable().FirstOrDefaultAsync(tool => tool.Model == model);


        

        public async Task<IEnumerable<Tool>> GetAllAsync() =>
            await Tools.AsQueryable().ToListAsync();

        public async Task AddAsync(Tool tool) =>
            await Tools.InsertOneAsync(tool);

        public async Task DeleteAsync(Guid id)
        {
            var tool = await GetAsyncId(id);
            //doesn't work
            await Tools.DeleteOneAsync(x => x.Box == tool.Box && x.Brand == tool.Brand
                                            && x.Model == tool.Model);
        }

        public async Task UpdateAsync(Tool tool)
        {
            //doesn't work 
            await Tools.AsQueryable().FirstAsync(x => x.Id == tool.Id);
        }

        public async Task<Tool> GetAsyncId(Guid id) =>
            await Tools.AsQueryable().FirstOrDefaultAsync(tool => tool.Id == id);

        private IMongoCollection<Tool> Tools => _database.GetCollection<Tool>("Tools");
    }
}