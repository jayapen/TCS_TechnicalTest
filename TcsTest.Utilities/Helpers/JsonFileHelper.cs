using System.Text.Json;
using TcsTest.Utilities.Constants;
using TcsTest.Utilities.Helpers.Interfaces;

namespace TcsTest.Utilities.Helpers
{
    public class JsonFileHelper : IJsonFileHelper
    {
        public async Task<List<T>> ReadAsync<T>(string filePath)
        {
            if(!File.Exists(filePath))
                return new List<T>();

            using FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return await JsonSerializer.DeserializeAsync<List<T>>(stream, _options) ?? new List<T>();
        }

        public async Task WriteAsync<T>(string filePath, IEnumerable<T> items)
        {
            var directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            using FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            await JsonSerializer.SerializeAsync(stream, items, _options);
        }

        private readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };
    }
}
