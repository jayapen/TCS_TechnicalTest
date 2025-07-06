using TCSTest.Entities;

namespace TCSTest.Repository.Interfaces
{
    public interface IChannelRepository
    {
        Task<List<Channel>> GetAllChannelAsync();
        Task<Channel?> GetChannelByIdAsync(Guid id);
        Task AddChannelAsync(Channel channel);
        Task UpdateChannelAsync(Guid id, Channel channel);
        Task DeleteChannelAsync(Guid id);
    }
}
