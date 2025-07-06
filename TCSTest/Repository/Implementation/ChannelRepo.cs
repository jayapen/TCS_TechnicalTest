using System.Text.Json;
using TCSTest.Repository.Interfaces;
using TCSTest.Entities;

namespace TCSTest.Repository.Implementation
{
    public class ChannelRepo : IChannelRepository
    {
        private readonly string _filePath = "Json Store/channels.json";

        public async Task<List<Channel>> GetAllChannelAsync()
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            using var stream = File.OpenRead(_filePath);
            var channels = await JsonSerializer.DeserializeAsync<List<Channel>>(stream, options);

            return channels ?? new List<Channel>();
        }

        public async Task<Channel?> GetChannelByIdAsync(Guid id)
        {
            var channels = await GetAllChannelAsync();
            return channels.FirstOrDefault(c => c.channelId == id);
        }

        private async Task SaveAsync(List<Channel> channels)
        {
            using var stream = File.Create(_filePath);
            await JsonSerializer.SerializeAsync(stream, channels, new JsonSerializerOptions { WriteIndented = true });
        }

        public async Task AddChannelAsync(Channel Nchannel)
        {
            var channels = await GetAllChannelAsync();
            channels.Add(Nchannel);
            await SaveAsync(channels);
        }
        public async Task UpdateChannelAsync(Guid id, Channel channelU)
        {
            var channels = await GetAllChannelAsync();
            var index = channels.FindIndex(c => c.channelId == channelU.channelId);
            if (index >= 0)
            {
                channels[index] = channelU;
                await SaveAsync(channels);
            }
        }
        public async Task DeleteChannelAsync(Guid id)
        {
            var channels = await GetAllChannelAsync();
            channels.RemoveAll(c => c.channelId == id);
            await SaveAsync(channels);
        }
    }
}
