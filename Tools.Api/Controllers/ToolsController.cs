using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tools.Infrastructure.Commands;
using Tools.Infrastructure.Commands.Tool;
using Tools.Infrastructure.Services.Interfaces;

namespace Tools.Api.Controllers
{
    [Route("[controller]")]
    public class ToolsController : ControllerBase
    {
        private readonly IToolService _toolService;

        public ToolsController(IToolService toolService,
            ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _toolService = toolService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tools = await _toolService.GetAllAsync();
            if (tools == null)
            {
                return NoContent();
            }
            return Json(tools);
        }

        /// <summary>
        /// gets a single tool of model and print it to json
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("{model}")]
        public async Task<IActionResult> Get(string model)
        {
            var tool = await _toolService.GetAsync(model);
            if (tool == null)
            {
                NoContent();
            }
            return Json(tool);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var tool = await _toolService.GetDetailsAsync(id);
            if (tool == null)
            {
                NoContent();
            }
            return Json(tool);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] AddTool command)
        {
            await DispatchAsync(command);
            return Created($"tools/{command.Id}", null);
        }

        [HttpPost("delete/{id}")]
        public async Task Post([FromBody] DeleteTool command)
        {
            await DispatchAsync(command);
        }
    }
}