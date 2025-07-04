using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TcsTest.Utilities.DTO;
using TcsTest.Utilities.Models;

namespace TCSTest.ServiceLayer.Interfaces
{
    public interface IContentCatalogService
    {
        Task<IEnumerable<ContentCatalog>> GetAllAsync();
        Task<ContentCatalog?> GetByIdAsync(Guid id);
        Task<ContentCatalog> CreateAsync(ContentCatalogDto dtoContent);
        Task<bool> UpdateAsync(Guid id, ContentCatalogDto dtoContent);
        Task<bool> DeleteAsync(Guid id);
    }
}
