namespace TCSTest.DTOs
{
    public class CatalogDto
    {
        public Guid contentId { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string genre { get; set; }
        public int durationMinutes { get; set; }
        public string rating { get; set; }
        public int year { get; set; }
        public int? season { get; set; }
        public int? episode { get; set; }
    }
}
