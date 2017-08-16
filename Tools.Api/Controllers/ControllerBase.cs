using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tools.Infrastructure.Commands;

namespace Tools.Api.Controllers
{
    [Route("[controller]")]
    public abstract class ControllerBase : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;

        protected ControllerBase(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        protected async Task DispatchAsync<T>(T command) where T : ICommand
        {
            await _commandDispatcher.DispatchAsync(command);
        }
        
    }
}