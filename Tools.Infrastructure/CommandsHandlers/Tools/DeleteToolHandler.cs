using System.Threading.Tasks;
using Tools.Infrastructure.Commands.Tool;
using Tools.Infrastructure.Services.Interfaces;
using Transporter.Infrastructure.Commends;

namespace Tools.Infrastructure.CommandsHandlers.Tools
{
    public class DeleteToolHandler : ICommandHandler<DeleteTool>
    {
        private readonly IToolService _toolService;

        public DeleteToolHandler(IToolService toolService)
        {
            _toolService = toolService;
        }


        public async Task HandleAsync(DeleteTool command)
        {
            await _toolService.DeleteAsync(command.Id);
        }
    }
}