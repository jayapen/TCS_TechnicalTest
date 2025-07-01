using TCSTest.Models.DTO;
using TCSTest.Models.Entities;
using TCSTest.Repository.Interface;
using TCSTest.Services.Interface;

namespace TCSTest.Services.Implementation
{
    public class ChannelService : IChannelService
    {
        private readonly IChannelRepository _repository;

        public ChannelService(IChannelRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ChannelDto>> GetAllAsync()
        {
            var channels = await _repository.GetAllAsync();

            return channels.Select(c => new ChannelDto
            {
                ChannelId = c.ChannelId,
                Name = c.Name,
                Category = c.Category,
                Language = c.Language,
                Region = c.Region
            });
        }

        public async Task<ChannelDto?> GetByIdAsync(Guid id)
        {
            var channels = await _repository.GetAllAsync();
            var c = channels.FirstOrDefault(x => x.ChannelId == id);

            if (c == null) return null;

            return new ChannelDto
            {
                ChannelId = c.ChannelId,
                Name = c.Name,
                Category = c.Category,
                Language = c.Language,
                Region = c.Region
            };
        }

        public async Task<ChannelDto> AddAsync(ChannelDto dto)
        {
            var channels = await _repository.GetAllAsync();

            var newChannel = new Channel
            {
                ChannelId = Guid.NewGuid(),
                Name = dto.Name,
                Category = dto.Category,
                Language = dto.Language,
                Region = dto.Region
            };

            channels.Add(newChannel);
            await _repository.SaveAllAsync(channels);

            return new ChannelDto
            {
                ChannelId = newChannel.ChannelId,
                Name = newChannel.Name,
                Category = newChannel.Category,
                Language = newChannel.Language,
                Region = newChannel.Region
            };
        }

        public async Task<bool> UpdateAsync(Guid id, ChannelDto dto)
        {
            var channels = await _repository.GetAllAsync();
            var index = channels.FindIndex(x => x.ChannelId == id);
            if (index == -1) return false;

            channels[index] = new Channel
            {
                ChannelId = id,
                Name = dto.Name,
                Category = dto.Category,
                Language = dto.Language,
                Region = dto.Region
            };

            await _repository.SaveAllAsync(channels);
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var channels = await _repository.GetAllAsync();
            var removed = channels.RemoveAll(x => x.ChannelId == id) > 0;

            if (removed)
                await _repository.SaveAllAsync(channels);

            return removed;
        }
    }
}
