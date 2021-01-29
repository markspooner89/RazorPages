using System.IO;
using System.Text.Json;
using RazorPageApp.Repositories.Interfaces;

namespace RazorPageApp.Repositories
{
    public class JsonFileHelper : IJsonFileHelper
    {
        public T Get<T>(string filePath)
        {
            using (var streamReader = File.OpenText(filePath))
            {
                return JsonSerializer.Deserialize<T>(
                    streamReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }
}