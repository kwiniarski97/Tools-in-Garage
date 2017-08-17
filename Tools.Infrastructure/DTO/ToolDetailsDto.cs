using System;

namespace Tools.Infrastructure.DTO
{
    public class ToolDetailsDto
    {
        public Guid Id { get; set; }
        
        public string Model { get; set; }

        public string Brand { get; set; }

        public string Type { get; set; }

        public uint Box { get; set; }
        
    }
}