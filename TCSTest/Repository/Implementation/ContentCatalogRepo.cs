using System.Text.Json;
using TCSTest.Entities;
using TCSTest.Repository.Interfaces;

namespace TCSTest.Repository.Implementation
{
    public class ContentCatalogRepo : ICatalogRepository
    {
        private readonly string _filePath = "Json Store/content_catalog.json";

        public async Task<List<Catalog>> GetAllCatalogAsync()
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            using var stream = File.OpenRead(_filePath);
            var contents = await JsonSerializer.DeserializeAsync<List<Catalog>>(stream, options);

            return contents ?? new List<Catalog>();
        }

        public async Task<Catalog?> GetCatalogByIdAsync(Guid id)
        {
            var catalogContent = await GetAllCatalogAsync();
            return catalogContent.FirstOrDefault(c => c.contentId == id);
        }

        private async Task SaveAsync(List<Catalog> catalogs)
        {
            using var stream = File.Create(_filePath);
            await JsonSerializer.SerializeAsync(stream, catalogs, new JsonSerializerOptions { WriteIndented = true });
        }

        public async Task AddCatalogAsync(Catalog catalog)
        {
            var catalogContent = await GetAllCatalogAsync();
            catalogContent.Add(catalog);
            await SaveAsync(catalogContent);
        }
        public async Task UpdateCatalogAsync(Guid id, Catalog catalog)
        {
            var catalogContent = await GetAllCatalogAsync();
            var index = catalogContent.FindIndex(c => c.contentId == catalog.contentId);
            if (index >= 0)
            {
                catalogContent[index] = catalog;
                await SaveAsync(catalogContent);
            }
        }
        public async Task DeleteCatalogAsync(Guid id)
        {
            var catalogContent = await GetAllCatalogAsync();
            catalogContent.RemoveAll(c => c.contentId == id);
            await SaveAsync(catalogContent);
        }
    }
}
