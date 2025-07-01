using System.Text.Json;
using TCSTest.Models.Entities;
using TCSTest.Repository.Interface;

namespace TCSTest.Repository.Implementation
{
    public class ChannelRepository : IChannelRepository
    {
        private readonly string _filePath = "Json Store/channels.json";

        public async Task<List<Channel>> GetAllAsync()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Channel>();
            }                

            try
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                using var stream = File.OpenRead(_filePath);
                var channels = await JsonSerializer.DeserializeAsync<List<Channel>>(stream, options);

                return channels ?? new List<Channel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load channels: {ex.Message}");
                return new List<Channel>();
            }
        }


        public async Task SaveAllAsync(List<Channel> channels)
        {
            var json = JsonSerializer.Serialize(channels, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}
