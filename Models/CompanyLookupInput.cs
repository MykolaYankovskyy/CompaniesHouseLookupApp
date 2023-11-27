using CsvHelper.Configuration.Attributes;

namespace CompaniesHouseLookup.Models
{
    public class CompanyLookupInput
    {
        [Name("Company Name")]
        public string? CompanyName { get; set; }
    }
}
