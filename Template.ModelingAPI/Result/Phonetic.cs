using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.ModelingAPI.Result
{
    public class Phonetic
    {
        [JsonProperty("audio")]
        public string Audio { get; set; }

        [JsonProperty("sourceUrl")]
        public string SourceUrl { get; set; }

        [JsonProperty("license")]
        public License License { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}