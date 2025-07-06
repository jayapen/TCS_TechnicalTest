using System.Text.Json;
using TCSTest.Entities;
using TCSTest.Repository.Interfaces;

namespace TCSTest.Repository.Implementation
{
    public class ChannelSchedulerRepo : ISchedulerRepository
    {
        private readonly string _filePath = "Json Store/Channelschedule.json";

        public async Task<List<ChannelScheduler>> GetAllSchedulerAsync()
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            using var stream = File.OpenRead(_filePath);
            var channelSchedule = await JsonSerializer.DeserializeAsync<List<ChannelScheduler>>(stream, options);

            return channelSchedule ?? new List<ChannelScheduler>();
        }

        private async Task SaveAsync(List<ChannelScheduler> schedules)
        {
            using var stream = File.Create(_filePath);
            await JsonSerializer.SerializeAsync(stream, schedules, new JsonSerializerOptions { WriteIndented = true });
        }

        public async Task SaveScheduleAllAsync(ChannelScheduler scheduler)
        {
            var channels = await GetAllSchedulerAsync();
            channels.Add(scheduler);
            await SaveAsync(channels);
        }

        public async Task UpdateScheduleAsync(Guid channelId, Guid contentId, ChannelScheduler channelScheduler)
        {
            var schedulers = await GetAllSchedulerAsync();
            var index = schedulers.FindIndex(c => c.channelId == channelScheduler.channelId && c.contentId == channelScheduler.contentId);
            if (index >= 0)
            {
                schedulers[index] = channelScheduler;
                await SaveAsync(schedulers);
            }
        }

        public async Task DeleteScheduleAsync(Guid channelId, Guid contentId)
        {
            var schedulers = await GetAllSchedulerAsync();
            schedulers.RemoveAll(c => c.channelId == channelId && c.contentId == contentId);
            await SaveAsync(schedulers);
        }
    }
}
