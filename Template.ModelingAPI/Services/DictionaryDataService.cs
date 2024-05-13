using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Template.ModelingAPI.Result;

namespace Template.ModelingAPI.Services
{
    public class DictionaryDataService : IDictionaryDataService
    {
        private readonly DictionaryModelingHttpClient _client;

        public DictionaryDataService(DictionaryModelingHttpClient client)
        {
            _client = client;
        }

        public async Task<WordDefinition> GetMeaning(string text)
        {
            string uri = text;
            var result = await _client.GetAsync<List<WordDefinition>>(uri);
            if (result == null || result.Count() == 0)
            {
                throw new InvalidDataException();
            }
            return result.FirstOrDefault();
        }
    }
}