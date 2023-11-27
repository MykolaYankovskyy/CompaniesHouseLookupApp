using CsvHelper.Configuration.Attributes;

namespace CompaniesHouseLookup.Models
{
    public class CompanyLookupOutput
    {
        [Name("Input Company Name")]
        public string? InputCompanyName { get; set; }

        [Name("Company Name")]
        public string? CompanyName { get; set; }

        [Name("Company Number")]
        public string? CompanyNumber { get; set; }
    }
}
