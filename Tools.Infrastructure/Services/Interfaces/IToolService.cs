using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tools.Core.Domain;
using Tools.Infrastructure.DTO;

namespace Tools.Infrastructure.Services.Interfaces
{
    /// <summary>
    /// Service is a class that mediate beetween repositories and controllers.
    /// Also using automapper to map Core Objects to DTO's objects
    /// </summary>
    public interface IToolService : IService
    {
        /// <summary>
        /// Gets details of tool of given model name
        /// </summary>
        /// <param name="model">model to get</param>
        /// <returns>ToolDto containing information of model</returns>
        Task<ToolDto> GetAsync(string model);

        /// <summary>
        /// Returns all tools and map them to IEnumerable of ToolDetails DTO's
        /// </summary>
        /// <returns>IEnumerable of ToolDetails DTO's</returns>
        Task<IEnumerable<ToolDetailsDto>> GetAllAsync();

        /// <summary>
        /// Creates a new tool in database
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="model">model</param>
        /// <param name="brand">brand</param>
        /// <param name="type">type</param>
        /// <param name="box">box number</param>
        Task AddAsync(Guid id, string model, string brand, string type, uint box);

        /// <summary>
        /// Delete a tool of given ID.
        /// !!WARNING!!
        /// This method unfortunatelly doesn't work because I didn't have time to fix ID translations.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Updates a tool
        /// !!WARNING!!
        /// This method unfortunatelly doesn't work because I didn't have time to fix ID translations.
        /// </summary>
        /// <param name="tool"></param>
        /// <returns></returns>
        Task UpdateAsync(Tool tool);
    }
}