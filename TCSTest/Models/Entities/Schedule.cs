using System.Text.Json.Serialization;

namespace TCSTest.Models.Entities
{
    public class ScheduleEntry
    {
        [JsonPropertyName("channelId")]
        public Guid ChannelId { get; set; }

        [JsonPropertyName("contentId")]
        public Guid ContentId { get; set; }

        [JsonPropertyName("airTime")]
        public DateTime AirTime { get; set; }

        [JsonPropertyName("endTime")]
        public DateTime EndTime { get; set; }
    }
}
