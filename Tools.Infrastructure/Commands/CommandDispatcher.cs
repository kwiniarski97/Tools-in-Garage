using System;
using System.Threading.Tasks;
using Autofac;
using Transporter.Infrastructure.Commends;

namespace Tools.Infrastructure.Commands
{
    /// <summary>
    /// Depends of what type of command IoC will get it will dispatch proper command
    /// </summary>
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }

        /// <summary>
        /// generic metod that fire off a proper command Handler dependable of command type
        /// </summary>
        /// <param name="command">generic command</param>
        /// <typeparam name="T"> generic type that inherits ICommand</typeparam>
        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if (command == null)
            {
                throw new ArgumentException(nameof(command), $"Command {typeof(T).Name}cannot be null.");
            }

            var handler = _context.Resolve<ICommandHandler<T>>();
            await handler.HandleAsync(command);
        }
    }
}