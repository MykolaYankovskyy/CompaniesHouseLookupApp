using Newtonsoft.Json;

namespace CompaniesHouseLookup.Models
{
    public class LinkObject
    {
        [JsonProperty("self")]
        public string? Self { get; set; }
    }
}
