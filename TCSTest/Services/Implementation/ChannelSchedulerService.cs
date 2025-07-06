using TCSTest.DTOs;
using TCSTest.Entities;
using TCSTest.Repository.Interfaces;
using TCSTest.Services.Interfaces;

namespace TCSTest.Services.Implementation
{
    public class ChannelSchedulerService : ISchedulerService
    {
        private readonly ISchedulerRepository _Schedulerrepository;

        public ChannelSchedulerService(ISchedulerRepository schedulerRepository)
        {
            _Schedulerrepository = schedulerRepository;
        }

        public async Task<IEnumerable<ChannelSchedulerDto>> GetAllScheduleAsync()
        {
            var scheduler = await _Schedulerrepository.GetAllSchedulerAsync();

            return scheduler.Select(s => new ChannelSchedulerDto
            {
                channelId = s.channelId,
                contentId = s.contentId,
                airTime = s.airTime,
                endTime = s.endTime
            });
        }

        public async Task<IEnumerable<ChannelSchedulerDto>> GetScheduleByChannelAsync(Guid channelId)
        {
            var schedules = await _Schedulerrepository.GetAllSchedulerAsync();
            return schedules
                .Where(s => s.channelId == channelId)
                .Select(s => new ChannelSchedulerDto
                {
                    channelId = s.channelId,
                    contentId = s.contentId,
                    airTime = s.airTime,
                    endTime = s.endTime
                });
        }

        public async Task<IEnumerable<ChannelSchedulerDto>> GetCurrentlyAiringAsync(DateTime now)
        {
            var schedules = await _Schedulerrepository.GetAllSchedulerAsync();
            return schedules
                .Where(s => s.airTime <= now && now <= s.endTime)
                .Select(s => new ChannelSchedulerDto
                {
                    channelId = s.channelId,
                    contentId = s.contentId,
                    airTime = s.airTime,
                    endTime = s.endTime
                });
        }


        public async Task<string> AddScheduleAsync(ChannelSchedulerDto sdto)
        {
            var schedule = new ChannelScheduler
            {
                channelId = sdto.channelId,
                contentId = sdto.contentId,
                airTime = sdto.airTime,
                endTime = sdto.endTime
            };

            await _Schedulerrepository.SaveScheduleAllAsync(schedule);
            return "Success";
        }

        public async Task<string> UpdateScheduleAsync(Guid channelId, Guid contentId, ChannelSchedulerDto sdto)
        {
            var schedule = new ChannelScheduler
            {
                channelId = sdto.channelId,
                contentId = sdto.contentId,
                airTime = sdto.airTime,
                endTime = sdto.endTime
            };

            await _Schedulerrepository.UpdateScheduleAsync(channelId, contentId, schedule);
            return "Success";
        }

        public async Task<string> DeleteScheduleAsync(Guid channelId, Guid contentId)
        {
            await _Schedulerrepository.DeleteScheduleAsync(channelId, contentId);
            return "Success";
        }
    }
}
