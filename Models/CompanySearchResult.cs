using Newtonsoft.Json;

namespace CompaniesHouseLookup.Models
{
    public class CompanySearchResult
    {
        [JsonProperty("etag")]
        public string? Etag { get; set; }

        [JsonProperty("items")]
        public List<ResultItems>? Items { get; set; }

        [JsonProperty("items_per_page")]
        public int? ItemsPerPage { get; set; }

        [JsonProperty("kind")]
        public string? Kind { get; set; }

        [JsonProperty("start_index")]
        public int? StartIndex { get; set; }

        [JsonProperty("total_results")]
        public int? TotalResults { get; set; }
    }
}
