using Newtonsoft.Json;

namespace CompaniesHouseLookup.Models
{
    public class MatchObject
    {
        [JsonProperty("address_snippet")]
        public List<int>? AddressSnippet { get; set; }

        [JsonProperty("snippet")]
        public List<int>? Snippet { get; set; }

        [JsonProperty("title")]
        public List<int>? Title { get; set; }
    }
}
