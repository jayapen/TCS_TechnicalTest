using System.Text.Json.Serialization;

namespace TCSTest.Entities
{
    public class ChannelScheduler
    {
        [JsonPropertyName("channelId")]
        public Guid channelId { get; set; }

        [JsonPropertyName("contentId")]
        public Guid contentId { get; set; }

        [JsonPropertyName("airTime")]
        public DateTime airTime { get; set; }

        [JsonPropertyName("endTime")]
        public DateTime endTime { get; set; }
    }
}
