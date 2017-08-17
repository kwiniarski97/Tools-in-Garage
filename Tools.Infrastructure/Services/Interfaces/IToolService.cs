using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tools.Core.Domain;
using Tools.Infrastructure.DTO;

namespace Tools.Infrastructure.Services.Interfaces
{
    public interface IToolService : IService
    {
        Task<ToolDto> GetAsync(string model);

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

        Task DeleteAsync(Guid id);

        Task UpdateAsync(Tool tool);
    }
}