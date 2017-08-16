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

        Task<IEnumerable<ToolDto>> GetAllAsync();

        Task<IEnumerable<ToolDto>> GetAllOfTypeAsync(string type);

        Task<ToolDetailsDto> GetDetailsAsync(Guid id);

        Task AddAsync(Guid id, string model, string brand, string type, uint box);
        
        Task DeleteAsync(Guid id);

        Task UpdateAsync(Tool tool);
    }
}