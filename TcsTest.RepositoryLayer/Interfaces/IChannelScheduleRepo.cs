using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcsTest.Utilities.Models;

namespace TcsTest.RepositoryLayer.Interfaces
{
    public interface IChannelScheduleRepo
    {
        Task<IEnumerable<ChannelSchedule>> GetAllAsync();
        Task<ChannelSchedule?> GetByIdAsync(Guid id);
        Task CreateAsync(ChannelSchedule schedule);
        Task UpdateAsync(ChannelSchedule schedule);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<ChannelSchedule>> GetByChannelAsync(Guid channelId);
        Task<IEnumerable<ChannelSchedule>> GetByDateAsync(DateTime date);
        Task<IEnumerable<ChannelSchedule>> GetCurrentlyAiringAsync(Guid? channelId, DateTime? dateTime);

    }
}
