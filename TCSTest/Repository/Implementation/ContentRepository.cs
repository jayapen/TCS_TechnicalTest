using System.Text.Json;
using TCSTest.Models.Entities;
using TCSTest.Repository.Interface;

namespace TCSTest.Repository.Implementation
{
    public class ContentRepository : IContentRepository
    {
        private readonly string _filePath = "Json Store/content_catalog.json";

        private async Task<List<Content>> LoadAsync()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Content>();
            }

            try
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                using var stream = File.OpenRead(_filePath);
                var contents = await JsonSerializer.DeserializeAsync<List<Content>>(stream, options);

                return contents ?? new List<Content>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load content: {ex.Message}");
                return new List<Content>();
            }
        }

        private async Task SaveAsync(List<Content> contents)
        {
            using var stream = File.Create(_filePath);
            await JsonSerializer.SerializeAsync(stream, contents, new JsonSerializerOptions { WriteIndented = true });
        }

        public async Task<List<Content>> GetAllAsync() 
        {
            return await LoadAsync(); 
        }

        public async Task<Content?> GetByIdAsync(Guid id)
        {
            var contents = await LoadAsync();
            return contents.FirstOrDefault(c => c.ContentId == id);
        }

        public async Task AddAsync(Content content)
        {
            var contents = await LoadAsync();
            contents.Add(content);
            await SaveAsync(contents);
        }

        public async Task UpdateAsync(Content content)
        {
            var contents = await LoadAsync();
            var index = contents.FindIndex(c => c.ContentId == content.ContentId);
            if (index >= 0)
            {
                contents[index] = content;
                await SaveAsync(contents);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var contents = await LoadAsync();
            contents.RemoveAll(c => c.ContentId == id);
            await SaveAsync(contents);
        }
    }
}
