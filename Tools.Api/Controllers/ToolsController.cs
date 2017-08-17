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

        /// <summary>
        /// Gets a IEnumerable of all tools from tool service.
        ///  If there is't any tools returns no content.
        /// PATH: ie. localhost/tools
        /// </summary>
        /// <returns>List of tools as JSON</returns>
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
        /// PATH: ie. localhost/tools/h43-asd1
        /// </summary>
        /// <param name="model">model to get</param>
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

        /// <summary>
        /// Adds a tool using a Add tool command
        /// PATH: ie. localhost/tools 
        /// In POST you should give JSON 
        /// {
        /// 	"model" : "QuadBox",
        ///	    "brand" : "SAE",
        ///	    "type" : "wrench",
        ///	    "box" : 1
        /// }
        /// </summary>
        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] AddTool command)
        {
            await DispatchAsync(command);
            return Created($"tools/{command.Model}", null);
        }

        /// <summary>
        /// Delete a tool
        /// PATH: ie. localhost/tools/delete
        /// In POST you should give JSON 
        /// {
        /// 	"id" : "67dcd4c7-3e47-4594-b892-b9a8b318228d"
        /// }
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("delete")]
        public async Task Post([FromBody] DeleteTool command)
        {
            await DispatchAsync(command);
        }

        [HttpPut("update")]
        public async Task Put([FromBody] UpdateTool command)
        {
            await DispatchAsync(command);
        }
    }
}