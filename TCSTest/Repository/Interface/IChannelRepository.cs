using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCSTest.Models.Entities;

namespace TCSTest.Repository.Interface
{
    public interface IChannelRepository
    {
        Task<List<Channel>> GetAllAsync();
        Task SaveAllAsync(List<Channel> channels);
    }
}