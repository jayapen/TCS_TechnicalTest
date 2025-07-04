using TcsTest.Utilities.Models;

namespace TcsTest.RepositoryLayer.Interfaces
{
    public interface IChannelRepo
    {
        Task<IEnumerable<Channel>> GetAllAsync();
        Task<Channel?> GetByIdAsync(Guid id);
        Task CreateAsync(Channel channel);
        Task UpdateAsync(Channel channel);
        Task<bool> DeleteAsync(Guid id);
    }
}
