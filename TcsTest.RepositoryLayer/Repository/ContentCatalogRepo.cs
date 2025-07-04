using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TcsTest.RepositoryLayer.Interfaces;
using TcsTest.Utilities.Constants;
using TcsTest.Utilities.DTO;
using TcsTest.Utilities.Helpers.Interfaces;
using TcsTest.Utilities.Models;

namespace TcsTest.RepositoryLayer.Repository
{
    public class ContentCatalogRepo : IContentCatalogRepo
    {
        private readonly IJsonFileHelper _jsonFileHelper;

        public ContentCatalogRepo(IJsonFileHelper jsonHelper)
        {
            _jsonFileHelper = jsonHelper;
        }

        public async Task<IEnumerable<ContentCatalog>> GetAllAsync()
        {
            try
            {
                return await _jsonFileHelper.ReadAsync<ContentCatalog>(FilePaths.Content);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error reading content catalog", ex);
            }
        }

        public async Task<ContentCatalog?> GetByIdAsync(Guid id)
        {
            try
            {
                var contentList = await _jsonFileHelper.ReadAsync<ContentCatalog>(FilePaths.Content);
                return contentList.FirstOrDefault(c => c.ContentId == id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error fetching content with ID {id}", ex);
            }
        }

        public async Task CreateAsync(ContentCatalog content)
        {
            try
            {
                var contentList = (await _jsonFileHelper.ReadAsync<ContentCatalog>(FilePaths.Content)).ToList();
                contentList.Add(content);
                await _jsonFileHelper.WriteAsync(FilePaths.Content, contentList);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error creating content", ex);
            }
        }

        public async Task UpdateAsync(ContentCatalog content)
        {
            try
            {
                var contentList = (await _jsonFileHelper.ReadAsync<ContentCatalog>(FilePaths.Content)).ToList();
                var index = contentList.FindIndex(c => c.ContentId == content.ContentId);
                if (index >= 0)
                {
                    contentList[index] = content;
                    await _jsonFileHelper.WriteAsync(FilePaths.Content, contentList);
                }
                else
                {
                    throw new KeyNotFoundException("Content not found for update.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error updating content", ex);
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var contentList = (await _jsonFileHelper.ReadAsync<ContentCatalog>(FilePaths.Content)).ToList();
                var removed = contentList.RemoveAll(c => c.ContentId == id) > 0;
                if (removed)
                {
                    await _jsonFileHelper.WriteAsync(FilePaths.Content, contentList);
                }
                return removed;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error deleting content with ID {id}", ex);
            }
        }
    }
}
