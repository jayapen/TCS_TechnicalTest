using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcsTest.Utilities.DTO;
using TcsTest.Utilities.Models;

namespace TCSTest.ServiceLayer.Interfaces
{
    public interface IChannelService
    {
        Task<IEnumerable<Channel>> GetAllAsync();
        Task<Channel?> GetByIdAsync(Guid id);
        Task<Channel> CreateAsync(ChannelDto dto);
        Task<bool> UpdateAsync(Guid id, ChannelDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
