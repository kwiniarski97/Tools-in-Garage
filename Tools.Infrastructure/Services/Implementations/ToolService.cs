using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Tools.Core.Domain;
using Tools.Core.Repositories;
using Tools.Infrastructure.DTO;
using Tools.Infrastructure.Services.Interfaces;

namespace Tools.Infrastructure.Services.Implementations
{
    public class ToolService : IToolService
    {
        private readonly IToolRepository _toolRepository;
        private readonly IMapper _mapper;

        public ToolService(IToolRepository toolRepository, IMapper mapper)
        {
            _toolRepository = toolRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Select a tool from repository
        /// </summary>
        /// <param name="model">model of tool to be returned</param>
        /// <returns>Tool as an ToolDTO object</returns>
        public async Task<ToolDto> GetAsync(string model)
        {
            var tool = await _toolRepository.GetAsync(model);
            return _mapper.Map<ToolDto>(tool);
        }

        /// <summary>
        /// Select all tools from database and map them to Dto's
        /// </summary>
        /// <returns>Returns a Ienumerable object with all tools as ToolDTO's objects</returns>
        public async Task<IEnumerable<ToolDetailsDto>> GetAllAsync()
        {
            var tools = await _toolRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ToolDetailsDto>>(tools);
        }

        
        public async Task AddAsync(Guid id, string model, string brand, string type, uint box)
        {
            var tool = await _toolRepository.GetAsync(id);
            if (tool != null)
            {
                throw new Exception($"Tool with id {id} already exists.");
            }

            tool = new Tool(id, model, brand, type, box);
            await _toolRepository.AddAsync(tool);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _toolRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(Tool tool)
        {
            await _toolRepository.UpdateAsync(tool);
        }

    }
}