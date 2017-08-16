using System;

namespace Tools.Infrastructure.Commands.Tool
{
    public class AddTool : ICommand
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public uint Box { get; set; }
    }
}