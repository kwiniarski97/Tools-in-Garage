﻿using System.Threading.Tasks;
using Tools.Infrastructure.Commands;

namespace Transporter.Infrastructure.Commends
{
    public interface ICommandHandler<T> : ICommand //generic for commands
    {
        Task HandleAsync(T command);
    }
}