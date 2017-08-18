using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tools.Core.Domain;

namespace Tools.Core.Repositories
{
    public interface IToolRepository : IRepository
    {
        /// <summary>
        /// Get general info about a specific model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Tool> GetAsyncId(string model);

        /// <summary>
        /// Get a tool from database using its Id.
        /// </summary>
        /// <param name="id">Id of tool</param>
        /// <returns>Tool of given id</returns>
        Task<Tool> GetAsyncId(Guid id);

        /// <summary>
        /// Gets all tools
        /// </summary>
        /// <returns>IEnumerable of Tools</returns>
        Task<IEnumerable<Tool>> GetAllAsync();

        /// <summary>
        /// Add a tool
        /// </summary>
        /// <param name="tool">tool object</param>
        Task AddAsync(Tool tool);

        /// <summary>
        /// Delete tool
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Update tool
        /// </summary>
        /// <param name="tool"></param>
        /// <returns></returns>
        Task UpdateAsync(Tool tool);
    }
}