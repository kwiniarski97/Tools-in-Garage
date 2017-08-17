using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tools.Core.Domain;
using Tools.Core.Repositories;

namespace Tools.Infrastructure.Repositories
{
    /// <summary>
    /// Repository of tools in memory
    /// </summary>
    public class LocalToolRepository : IToolRepository
    {
        private ISet<Tool> _tools = new HashSet<Tool>();

        public async Task<Tool> GetAsync(string model) =>
            await Task.FromResult(_tools.SingleOrDefault(x => x.Model == model));

        public async Task<Tool> GetAsync(Guid id) =>
            await Task.FromResult(_tools.SingleOrDefault(x => x.Id == id));

        public async Task<IEnumerable<Tool>> GetAllAsync() =>
            await Task.FromResult(_tools);

        public async Task<IEnumerable<Tool>> GetAllOfTypeAsync(string type) =>
            await Task.FromResult(_tools.Where(x => x.Type == type));


        public async Task AddAsync(Tool tool) =>
            await Task.FromResult(_tools.Add(tool));


        public async Task DeleteAsync(Guid id)
        {
            var tool = await GetAsync(id);
            await Task.FromResult(_tools.Remove(tool));
        }

        public async Task UpdateAsync(Tool toolToUpdate)
        {
            var id = toolToUpdate.Id;
            var tool = await GetAsync(id);
            if (tool == null)
            {
                throw new Exception("Theres no matching tool in repository");
            }
            await DeleteAsync(id);
            await AddAsync(tool);
        }
    }
}