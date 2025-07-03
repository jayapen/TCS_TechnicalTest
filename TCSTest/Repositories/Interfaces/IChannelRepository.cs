using TCSTest.Models;

namespace TCSTest.Repositories.Interfaces;

public interface IChannelRepository
{
    Task<List<Channel>> GetAllAsync();
    Task<Channel?> GetByIdAsync(Guid id);
    Task AddAsync(Channel channel);
    Task<bool> UpdateAsync(Guid id, Channel channel);
    Task<bool> DeleteAsync(Guid id);

}