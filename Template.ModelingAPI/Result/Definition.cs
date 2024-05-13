using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.ModelingAPI.Result
{
    public class Definition
    {
        [JsonProperty("definition")]
        public string DefinitionText { get; set; }

        [JsonProperty("synonyms")]
        public List<object> Synonyms { get; set; }

        [JsonProperty("antonyms")]
        public List<object> Antonyms { get; set; }

        [JsonProperty("example")]
        public string Example { get; set; }
    }
}