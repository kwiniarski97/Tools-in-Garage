using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tools.Core.Domain;

namespace Tools.Core.Repositories
{
    public interface IToolRepository : IRepository
    {
        Task<Tool> GetAsync(string model);

        Task<Tool> GetAsync(Guid id);

        Task<IEnumerable<Tool>> GetAllAsync();

        Task<IEnumerable<Tool>> GetAllOfTypeAsync(string type);

        Task AddAsync(Tool tool);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(Tool tool);
    }
}