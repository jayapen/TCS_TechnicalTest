using TcsTest.RepositoryLayer.Interfaces;
using TcsTest.Utilities.DTO;
using TcsTest.Utilities.Models;
using TCSTest.ServiceLayer.Interfaces;

namespace TCSTest.ServiceLayer.Services
{
    public class ChannelService : IChannelService
    {
        private readonly IChannelRepo _repository;

        public ChannelService(IChannelRepo repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Channel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Channel?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Channel> CreateAsync(ChannelDto dto)
        {
            var channel = new Channel
            {
                ChannelId = Guid.NewGuid(),
                Name = dto.Name,
                Category = dto.Category,
                Language = dto.Language,
                Region = dto.Region
            };

            await _repository.CreateAsync(channel);
            return channel;
        }

        public async Task<bool> UpdateAsync(Guid id, ChannelDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            existing.Name = dto.Name;
            existing.Category = dto.Category;
            existing.Language = dto.Language;
            existing.Region = dto.Region;

            await _repository.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
