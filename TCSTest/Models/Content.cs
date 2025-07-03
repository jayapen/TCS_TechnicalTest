using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TCSTest.Models
{
    public class Content
    {
        [JsonPropertyName("contentId")]
        public Guid ContentId { get; set; }

        [JsonPropertyName("title")]
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        [Required]
        [StringLength(50)]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("genre")]
        [Required]
        [StringLength(50)]
        public string Genre { get; set; } = string.Empty;

        [JsonPropertyName("durationMinutes")]
        [Range(1, 1440, ErrorMessage = "Duration must be between 1 and 1440 minutes.")]
        public int DurationMinutes { get; set; }

        [JsonPropertyName("rating")]
        [StringLength(10)]
        public string Rating { get; set; } = string.Empty;

        [JsonPropertyName("year")]
        [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100.")]
        public int Year { get; set; }

        [JsonPropertyName("season")]
        [Range(1, 100, ErrorMessage = "Season must be between 1 and 100.")]
        public int? Season { get; set; }

        [JsonPropertyName("episode")]
        [Range(1, 1000, ErrorMessage = "Episode must be between 1 and 1000.")]
        public int? Episode { get; set; }
    }
}
