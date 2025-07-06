using System.Text.Json.Serialization;

namespace TCSTest.Entities
{
    public class Channel
    {
        [JsonPropertyName("channelId")]
        public Guid channelId { get; set; }

        [JsonPropertyName("name")]
        public string channelName { get; set; } = string.Empty;

        [JsonPropertyName("category")]
        public string channelCategory { get; set; } = string.Empty;

        [JsonPropertyName("language")]
        public string language { get; set; } = string.Empty;

        [JsonPropertyName("region")]
        public string region { get; set; } = string.Empty;
    }
}
