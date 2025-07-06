using System.Text.Json.Serialization;

namespace TCSTest.Entities
{
    public class Catalog
    {
        [JsonPropertyName("contentId")]
        public Guid contentId { get; set; } = Guid.NewGuid();

        [JsonPropertyName("title")]
        public string title { get; set; }

        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonPropertyName("genre")]
        public string genre { get; set; }

        [JsonPropertyName("durationMinutes")]
        public int durationMinutes { get; set; }

        [JsonPropertyName("rating")]
        public string rating { get; set; }

        [JsonPropertyName("year")]
        public int year { get; set; }

        [JsonPropertyName("season")]
        public int? season { get; set; }

        [JsonPropertyName("episode")]
        public int? episode
        {
            get; set;
        }
    }
}
