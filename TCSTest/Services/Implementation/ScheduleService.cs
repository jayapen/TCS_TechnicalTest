using TCSTest.Models.DTO;
using TCSTest.Models.Entities;
using TCSTest.Repository.Interface;
using TCSTest.Services.Interface;

namespace TCSTest.Services.Implementation
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _repository;

        public ScheduleService(IScheduleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ScheduleDto>> GetAllAsync()
        {
            var schedules = await _repository.GetAllAsync();
            return schedules.Select(s => new ScheduleDto
            {
                ChannelId = s.ChannelId,
                ContentId = s.ContentId,
                AirTime = s.AirTime,
                EndTime = s.EndTime
            });
        }

        public async Task<IEnumerable<ScheduleDto>> GetByChannelAsync(Guid channelId)
        {
            var schedules = await _repository.GetAllAsync();
            return schedules
                .Where(s => s.ChannelId == channelId)
                .Select(s => new ScheduleDto
                {
                    ChannelId = s.ChannelId,
                    ContentId = s.ContentId,
                    AirTime = s.AirTime,
                    EndTime = s.EndTime
                });
        }

        public async Task<IEnumerable<ScheduleDto>> GetCurrentlyAiringAsync(DateTime now)
        {
            var schedules = await _repository.GetAllAsync();
            return schedules
                .Where(s => s.AirTime <= now && now <= s.EndTime)
                .Select(s => new ScheduleDto
                {
                    ChannelId = s.ChannelId,
                    ContentId = s.ContentId,
                    AirTime = s.AirTime,
                    EndTime = s.EndTime
                });
        }


        public async Task<bool> AddAsync(ScheduleDto dto)
        {
            var schedules = await _repository.GetAllAsync();

            if (schedules.Any(s =>
                s.ChannelId == dto.ChannelId &&
                s.AirTime < dto.EndTime &&
                dto.AirTime < s.EndTime))
            {
                return false;
            }

            schedules.Add(new ScheduleEntry
            {
                ChannelId = dto.ChannelId,
                ContentId = dto.ContentId,
                AirTime = dto.AirTime,
                EndTime = dto.EndTime
            });

            await _repository.SaveAllAsync(schedules);
            return true;
        }

        public async Task<bool> UpdateAsync(Guid channelId, Guid contentId, ScheduleDto dto)
        {
            var schedules = await _repository.GetAllAsync();
            var index = schedules.FindIndex(s => s.ChannelId == channelId && s.ContentId == contentId);
            if (index == -1)
                return false;

            schedules[index].AirTime = dto.AirTime;
            schedules[index].EndTime = dto.EndTime;

            await _repository.SaveAllAsync(schedules);
            return true;
        }

        public async Task<bool> DeleteAsync(Guid channelId, Guid contentId)
        {
            var schedules = await _repository.GetAllAsync();
            var removed = schedules.RemoveAll(s => s.ChannelId == channelId && s.ContentId == contentId) > 0;

            if (removed)
                await _repository.SaveAllAsync(schedules);

            return removed;
        }
    }
}
