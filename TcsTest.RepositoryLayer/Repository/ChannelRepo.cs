using TcsTest.RepositoryLayer.Interfaces;
using TcsTest.Utilities.Constants;
using TcsTest.Utilities.Helpers;
using TcsTest.Utilities.Helpers.Interfaces;
using TcsTest.Utilities.Models;

namespace TcsTest.RepositoryLayer.Repository
{

    public class ChannelRepo : IChannelRepo
    {
        private readonly IJsonFileHelper _jsonFileHelper;
        public ChannelRepo(IJsonFileHelper jsonHelper)
        {
            _jsonFileHelper = jsonHelper;
        }

        public async Task<IEnumerable<Channel>> GetAllAsync()
        {
            try
            {
                return await _jsonFileHelper.ReadAsync<Channel>(FilePaths.Channels);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error reading channels", ex);
            }
        }

        public async Task<Channel?> GetByIdAsync(Guid id)
        {
            try
            {
                var channels = await _jsonFileHelper.ReadAsync<Channel>(FilePaths.Channels);
                return channels.FirstOrDefault(c => c.ChannelId == id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error fetching channel with ID {id}", ex);
            }
        }

        public async Task CreateAsync(Channel channel)
        {
            try
            {
                var channels = (await _jsonFileHelper.ReadAsync<Channel>(FilePaths.Channels)).ToList();
                channels.Add(channel);
                await _jsonFileHelper.WriteAsync(FilePaths.Channels, channels);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error creating channel", ex);
            }
        }

        public async Task UpdateAsync(Channel channel)
        {
            try
            {
                var channels = (await _jsonFileHelper.ReadAsync<Channel>(FilePaths.Channels)).ToList();
                var index = channels.FindIndex(c => c.ChannelId == channel.ChannelId);
                if (index >= 0)
                {
                    channels[index] = channel;
                    await _jsonFileHelper.WriteAsync(FilePaths.Channels, channels);
                }
                else
                {
                    throw new KeyNotFoundException("Channel not found for update.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error updating channel", ex);
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var channels = (await _jsonFileHelper.ReadAsync<Channel>(FilePaths.Channels)).ToList();
                var removed = channels.RemoveAll(c => c.ChannelId == id) > 0;
                if (removed)
                {
                    await _jsonFileHelper.WriteAsync(FilePaths.Channels, channels);
                }
                return removed;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error deleting channel with ID {id}", ex);
            }
        }
    }
}
