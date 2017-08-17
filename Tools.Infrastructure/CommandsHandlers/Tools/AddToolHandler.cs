using System;
using System.Threading.Tasks;
using Tools.Infrastructure.Commands.Tool;
using Tools.Infrastructure.Services.Interfaces;
using Transporter.Infrastructure.Commends;

namespace Tools.Infrastructure.CommandsHandlers.Tools
{
    public class AddToolHandler : ICommandHandler<AddTool>
    {
        private readonly IToolService _toolService;

        public AddToolHandler(IToolService toolService)
        {
            _toolService = toolService;
        }

        public async Task HandleAsync(AddTool command)
        {
            await _toolService.AddAsync(new Guid(), command.Model, command.Brand, command.Type, command.Box);
        }
    }
}