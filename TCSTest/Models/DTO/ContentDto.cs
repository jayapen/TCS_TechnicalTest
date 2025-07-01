namespace TCSTest.Models.DTO
{
    public class ContentDto
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Genre { get; set; }
        public int DurationMinutes { get; set; }
        public string Rating { get; set; }
        public int Year { get; set; }
        public int? Season { get; set; }
        public int? Episode { get; set; }
    }
}