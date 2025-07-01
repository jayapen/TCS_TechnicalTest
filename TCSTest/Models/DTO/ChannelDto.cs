using System.Text.Json.Serialization;

namespace TCSTest.Models.DTO
{
    public class ChannelDto
    {
        public Guid ChannelId { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
    }
}