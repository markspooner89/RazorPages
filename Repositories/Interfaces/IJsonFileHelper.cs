namespace RazorPageApp.Repositories.Interfaces
{
    public interface IJsonFileHelper
    {
        T Get<T>(string filePath);
    }
}