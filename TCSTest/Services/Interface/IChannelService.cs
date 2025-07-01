using TCSTest.Models.DTO;

namespace TCSTest.Services.Interface
{
    public interface IChannelService
    {
        Task<IEnumerable<ChannelDto>> GetAllAsync();
        Task<ChannelDto> AddAsync(ChannelDto dto);
        Task<bool> UpdateAsync(Guid id, ChannelDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}