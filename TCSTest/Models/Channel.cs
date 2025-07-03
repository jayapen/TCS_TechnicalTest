using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TCSTest.Models
{
    public class Channel
    {
        [JsonPropertyName("channelId")]
        public Guid ChannelId { get; set; }

        [JsonPropertyName("name")]
        [Required(ErrorMessage = "Channel name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("category")]
        [StringLength(50, ErrorMessage = "Category cannot exceed 50 characters.")]
        public string Category { get; set; } = string.Empty;

        [JsonPropertyName("language")]
        [StringLength(50, ErrorMessage = "Language cannot exceed 50 characters.")]
        public string Language { get; set; } = string.Empty;

        [JsonPropertyName("region")]
        [StringLength(100, ErrorMessage = "Region cannot exceed 100 characters.")]
        public string Region { get; set; } = string.Empty;
    }
}
