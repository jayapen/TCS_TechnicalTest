using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCSTest.Models.Entities;

namespace TCSTest.Repository.Interface
{
    public interface IContentRepository
    {
        Task<List<Content>> GetAllAsync();
        Task<Content?> GetByIdAsync(Guid id);
        Task AddAsync(Content content);
        Task UpdateAsync(Content content);
        Task DeleteAsync(Guid id);
    }
}