using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.ModelingAPI.Result
{
    public class WordDefinition
    {
        [JsonProperty("word")]
        public string Word { get; set; }

        [JsonProperty("phonetics")]
        public List<Phonetic> Phonetics { get; set; }

        [JsonProperty("meanings")]
        public List<Meaning> Meanings { get; set; }

        [JsonProperty("license")]
        public License License { get; set; }

        [JsonProperty("sourceUrls")]
        public List<string> SourceUrls { get; set; }
    }
}