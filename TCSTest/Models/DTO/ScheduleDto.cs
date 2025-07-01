namespace TCSTest.Models.DTO
{
    public class ScheduleDto
    {
        public Guid ChannelId { get; set; }
        public Guid ContentId { get; set; }
        public DateTime AirTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
