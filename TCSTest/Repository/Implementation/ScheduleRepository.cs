using System.Text.Json;
using TCSTest.Models.Entities;
using TCSTest.Repository.Interface;

namespace TCSTest.Repository.Implementation
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly string _filePath = "Json Store/channel_schedule.json";

        public async Task<List<ScheduleEntry>> GetAllAsync()
        {
            if (!File.Exists(_filePath))
            { 
                return new List<ScheduleEntry>();
            }

            try
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                using var stream = File.OpenRead(_filePath);
                var schedules = await JsonSerializer.DeserializeAsync<List<ScheduleEntry>>(stream, options);

                return schedules ?? new List<ScheduleEntry>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load schedules: {ex.Message}");
                return new List<ScheduleEntry>();
            }
        }

        public async Task SaveAllAsync(List<ScheduleEntry> entries)
        {
            var json = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}
