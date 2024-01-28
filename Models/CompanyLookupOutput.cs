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

        [Name("Company Type")]
        public string? CompanyType { get; set; }

        [Name("Company Status")]
        public string? CompanyStatus { get; set; }

        [Name("Date of Creation")]
        public string? DateOfCreation { get; set; }

        [Name("Date of Cessation")]
        public string? DateOfCessation { get; set; }

        [Name("Address Line 1")]
        public string? AddressLine1 { get; set; }

        [Name("Address Line 2")]
        public string? AddressLine2 { get; set; }

        [Name("Care Of")]
        public string? CareOf { get; set; }

        [Name("Country")]
        public string? Country { get; set; }

        [Name("Locality")]
        public string? Locality { get; set; }

        [Name("PO Box")]
        public string? PoBox { get; set; }

        [Name("Postal Code")]
        public string? PostalCode { get; set; }

        [Name("Region")]
        public string? Region { get; set; }

        [Ignore]
        public List<string>? SICCodes { get; set; }

        [Name("SIC Codes")]
        public string? SICCodesString
        {
            get
            {
                if (SICCodes is null)
                {
                    return null;
                }

                var SICString = string.Empty;

                foreach (var SICCode in SICCodes)
                {
                    if (Constants.Constants.SICDescriptions.TryGetValue(SICCode, out string? value))
                    {
                        SICString += $"{SICCode} - {value}, ";
                    }
                }

                return SICString.TrimEnd(',', ' ');
            }
        }
    }
}
