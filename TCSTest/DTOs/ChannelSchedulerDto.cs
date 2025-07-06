namespace TCSTest.DTOs
{
    public class ChannelSchedulerDto
    {
        public Guid channelId { get; set; }
        public Guid contentId { get; set; }
        public DateTime airTime { get; set; }
        public DateTime endTime { get; set; }
    }
}
