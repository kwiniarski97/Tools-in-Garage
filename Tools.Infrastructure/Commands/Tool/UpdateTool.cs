using System;

namespace Tools.Infrastructure.Commands.Tool
{
    public class UpdateTool : ICommand

    {
        public Guid Id { get; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public uint Box { get; set; }
    }
}