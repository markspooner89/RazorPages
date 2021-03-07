using System.IO;
using System.Text.Json;

namespace Code.Data
{
    public interface IJsonFileHelper
    {
        T Get<T>(string filePath);
    }
    
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