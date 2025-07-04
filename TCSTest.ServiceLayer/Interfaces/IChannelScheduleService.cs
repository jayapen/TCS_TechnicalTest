using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcsTest.Utilities.DTO;
using TcsTest.Utilities.Models;

namespace TCSTest.ServiceLayer.Interfaces
{
    public interface IChannelScheduleService
    {
        Task<IEnumerable<ChannelSchedule>> GetAllAsync();
        Task<IEnumerable<ChannelSchedule>> GetByChannelAsync(Guid channelId);
        Task<IEnumerable<ChannelSchedule>> GetCurrentlyAiringAsync(Guid? channelId, DateTime? dateTime);
        Task CreateAsync(ChannelScheduleDto scheduleDto);
        Task<bool> UpdateAsync(Guid channelId, Guid contentId, ChannelScheduleDto scheduleDto);
        Task<bool> DeleteAsync(Guid channelId, Guid contentId);
    }
}
