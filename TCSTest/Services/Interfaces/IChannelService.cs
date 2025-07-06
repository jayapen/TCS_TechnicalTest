using TCSTest.DTOs;

namespace TCSTest.Services.Interfaces
{
    public interface IChannelService
    {
        Task<IEnumerable<ChannelDto>> GetAllChannelAsync();
        Task<ChannelDto?> GetChannelByIdAsync(Guid id);
        Task<Guid> AddChannelAsync(ChannelDto dto);
        Task<string> UpdateChannelAsync(Guid id, ChannelDto dto);
        Task<string> DeleteChannelAsync(Guid id);
    }
}
