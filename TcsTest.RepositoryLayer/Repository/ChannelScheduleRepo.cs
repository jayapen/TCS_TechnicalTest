using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcsTest.RepositoryLayer.Interfaces;
using TcsTest.Utilities.Constants;
using TcsTest.Utilities.Helpers.Interfaces;
using TcsTest.Utilities.Models;

namespace TcsTest.RepositoryLayer.Repository
{
    public class ChannelScheduleRepo : IChannelScheduleRepo
    {
        private readonly IJsonFileHelper _jsonFileHelper;

        public ChannelScheduleRepo(IJsonFileHelper jsonHelper)
        {
            _jsonFileHelper = jsonHelper;
        }

        public async Task<IEnumerable<ChannelSchedule>> GetAllAsync()
        {
            try
            {
                return await _jsonFileHelper.ReadAsync<ChannelSchedule>(FilePaths.Schedule);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error reading all schedules", ex);
            }
        }

        public async Task<ChannelSchedule?> GetByIdAsync(Guid id)
        {
            try
            {
                var data = await GetAllAsync();
                return data.FirstOrDefault(s => s.ScheduleId == id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error fetching schedule with ID {id}", ex);
            }
        }

        public async Task CreateAsync(ChannelSchedule schedule)
        {
            try
            {
                var data = (await GetAllAsync()).ToList();
                schedule.ScheduleId = Guid.NewGuid();
                data.Add(schedule);
                await _jsonFileHelper.WriteAsync(FilePaths.Schedule, data);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error creating schedule", ex);
            }
        }

        public async Task UpdateAsync(ChannelSchedule schedule)
        {
            try
            {
                var data = (await GetAllAsync()).ToList();
                var index = data.FindIndex(s => s.ScheduleId == schedule.ScheduleId);
                if (index != -1)
                {
                    data[index] = schedule;
                    await _jsonFileHelper.WriteAsync(FilePaths.Schedule, data);
                }
                else
                {
                    throw new KeyNotFoundException("Schedule not found for update.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error updating schedule", ex);
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var data = (await GetAllAsync()).ToList();
                var removed = data.RemoveAll(s => s.ScheduleId == id);
                if (removed > 0)
                {
                    await _jsonFileHelper.WriteAsync(FilePaths.Schedule, data);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error deleting schedule with ID {id}", ex);
            }
        }

        public async Task<IEnumerable<ChannelSchedule>> GetByChannelAsync(Guid channelId)
        {
            try
            {
                var data = await GetAllAsync();
                return data.Where(s => s.ChannelId == channelId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error fetching schedules for channel ID {channelId}", ex);
            }

        }

        public async Task<IEnumerable<ChannelSchedule>> GetByDateAsync(DateTime date)
        {
            try
            {
                var data = await GetAllAsync();
                return data.Where(s => s.AirTime.Date == date.Date);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error fetching schedules for date {date.ToShortDateString()}", ex);
            }
        }

        public async Task<IEnumerable<ChannelSchedule>> GetCurrentlyAiringAsync(Guid? channelId, DateTime? dateTime)
        {
            try
            {
                var now = dateTime ?? DateTime.UtcNow;
                var data = await GetAllAsync();
                return data.Where(s =>
                    (!channelId.HasValue || s.ChannelId == channelId.Value) &&
                    s.AirTime <= now && s.EndTime >= now);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error fetching currently airing schedules", ex);
            }
        }
    }
}
