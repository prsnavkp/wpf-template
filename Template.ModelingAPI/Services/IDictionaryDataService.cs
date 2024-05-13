using Template.ModelingAPI.Result;

namespace Template.ModelingAPI.Services
{
    public interface IDictionaryDataService
    {
        Task<WordDefinition> GetMeaning(string text);
    }
}