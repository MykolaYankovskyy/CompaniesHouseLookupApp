using Newtonsoft.Json;

namespace CompaniesHouseLookup.Models
{
    public class ResultItems
    {
        [JsonProperty("address")]
        public AddressObject? Address { get; set; }

        [JsonProperty("address_snippet")]
        public string? AddressSnippet { get; set; }

        [JsonProperty("company_number")]
        public string? CompanyNumber { get; set; }

        [JsonProperty("company_status")]
        public string? CompanyStatus { get; set; }

        [JsonProperty("company_type")]
        public string? CompanyType { get; set; }

        [JsonProperty("date_of_creation")]
        public string? DateOfCreation { get; set; }

        [JsonProperty("date_of_cessation")]
        public string? DateOfCessation { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("description_identifier")]
        public List<string>? DescriptionIdentifier { get; set; }

        [JsonProperty("kind")]
        public string? Kind { get; set; }

        [JsonProperty("links")]
        public LinkObject? Links { get; set; }

        [JsonProperty("matches")]
        public MatchObject? Matches { get; set; }

        [JsonProperty("snippet")]
        public string? Snippet { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }
    }
}
