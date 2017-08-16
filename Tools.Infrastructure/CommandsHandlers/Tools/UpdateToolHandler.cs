using System.Threading.Tasks;
using Tools.Core.Domain;
using Tools.Infrastructure.Commands.Tool;
using Tools.Infrastructure.Services.Interfaces;
using Transporter.Infrastructure.Commends;

namespace Tools.Infrastructure.CommandsHandlers.Tools
{
    public class UpdateToolHandler : ICommandHandler<UpdateTool>
    {
        private readonly IToolService _toolService;

        public UpdateToolHandler(IToolService toolService)
        {
            _toolService = toolService;
        }


        public async Task HandleAsync(UpdateTool command)
        {
            var tool = new Tool(command.Id, command.Model, command.Brand,
                command.Type, command.Box);
            await _toolService.UpdateAsync(tool);
        }
    }
}