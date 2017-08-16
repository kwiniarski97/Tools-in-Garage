using System;

namespace Tools.Infrastructure.Commands.Tool
{
    public class DeleteTool : ICommand
    {
        public Guid Id { get; set; }
    }
}