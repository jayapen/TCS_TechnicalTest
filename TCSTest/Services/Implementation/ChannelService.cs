using TCSTest.DTOs;
using TCSTest.Entities;
using TCSTest.Repository.Interfaces;
using TCSTest.Services.Interfaces;

namespace TCSTest.Services.Implementation
{
    public class ChannelService :IChannelService
    {
        private readonly IChannelRepository _Channelrepository;

        public ChannelService(IChannelRepository channelRepository)
        {
            _Channelrepository = channelRepository;
        }

        public async Task<IEnumerable<ChannelDto>> GetAllChannelAsync()
        {
            var channels = await _Channelrepository.GetAllChannelAsync();

            return channels.Select(c => new ChannelDto
            {
                channelId = c.channelId,
                channelName = c.channelName,
                channelCategory = c.channelCategory,
                language = c.language,
                region = c.region,
            });
        }

        public async Task<ChannelDto?> GetChannelByIdAsync(Guid id)
        {
            var channels = await _Channelrepository.GetChannelByIdAsync(id);
            return new ChannelDto
            {
                channelName = channels.channelName,
                channelCategory = channels.channelCategory,
                language = channels.language,
                region = channels.region,
            };
        }

        public async Task<Guid> AddChannelAsync(ChannelDto cDto)
        {
            var channels = new Channel
            {
                channelId = new Guid(),
                channelName = cDto.channelName,
                channelCategory = cDto.channelCategory,
                language = cDto.language,
                region = cDto.region,
            };

            await _Channelrepository.AddChannelAsync(channels);
            return channels.channelId;
        }

        public async Task<string> UpdateChannelAsync(Guid id, ChannelDto cDto)
        {
            var channels = new Channel
            {
                channelId = id,
                channelName = cDto.channelName,
                channelCategory = cDto.channelCategory,
                language = cDto.language,
                region = cDto.region,
            };

            await _Channelrepository.UpdateChannelAsync(channels.channelId, channels);
            return "Success";
        }

        public async Task<string> DeleteChannelAsync(Guid id)
        {
            await _Channelrepository.DeleteChannelAsync(id);
            return "Success";
        }
    }
}
