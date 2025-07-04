using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcsTest.RepositoryLayer.Interfaces;
using TcsTest.Utilities.DTO;
using TcsTest.Utilities.Models;
using TCSTest.ServiceLayer.Interfaces;

namespace TCSTest.ServiceLayer.Services
{
    public class ChannelScheduleService : IChannelScheduleService
    {
        private readonly IChannelScheduleRepo _channelScheduleRepo;

        public ChannelScheduleService(IChannelScheduleRepo channelScheduleRepository)
        {
            _channelScheduleRepo = channelScheduleRepository;
        }

        public async Task<IEnumerable<ChannelSchedule>> GetAllAsync()
        {
            return await _channelScheduleRepo.GetAllAsync();
        }

        public async Task<IEnumerable<ChannelSchedule>> GetByChannelAsync(Guid channelId)
        {
            return await _channelScheduleRepo.GetByChannelAsync(channelId);
        }

        public async Task<IEnumerable<ChannelSchedule>> GetCurrentlyAiringAsync(Guid? channelId, DateTime? dateTime)
        {
            return await _channelScheduleRepo.GetCurrentlyAiringAsync(channelId, dateTime);
        }

        public async Task CreateAsync(ChannelScheduleDto dto)
        {
            var schedule = new ChannelSchedule
            {
                ChannelId = dto.ChannelId,
                ContentId = dto.ContentId,
                AirTime = dto.AirTime,
                EndTime = dto.EndTime
            };

            await _channelScheduleRepo.CreateAsync(schedule);
        }

        public async Task<bool> UpdateAsync(Guid channelId, Guid contentId, ChannelScheduleDto dto)
        {
            var all = await _channelScheduleRepo.GetAllAsync();
            var schedule = all.FirstOrDefault(s => s.ChannelId == channelId && s.ContentId == contentId);
            if (schedule == null) return false;

            schedule.AirTime = dto.AirTime;
            schedule.EndTime = dto.EndTime;

            await _channelScheduleRepo.UpdateAsync(schedule);
            return true;
        }

        public async Task<bool> DeleteAsync(Guid channelId, Guid contentId)
        {
            var all = await _channelScheduleRepo.GetAllAsync();
            var schedule = all.FirstOrDefault(s => s.ChannelId == channelId && s.ContentId == contentId);
            if (schedule == null) return false;

            return await _channelScheduleRepo.DeleteAsync(schedule.ScheduleId);
        }
    }
}
