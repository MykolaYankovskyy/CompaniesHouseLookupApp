using CompaniesHouseLookup.Models;
using Newtonsoft.Json;
using System.Text;
using System.Linq;
using CompaniesHouseLookupApp.Models;

namespace CompaniesHouseLookup.Services
{
    public class CompaniesHouseLookupService()
    {
        public static async Task<List<CompanyLookupOutput>> GetCompanyDetails(string input, string apiKey)
        {
            var companySearchResult = await SearchCompanies(input, apiKey);
            Console.WriteLine($"Found {companySearchResult?.Items?.Count} companies matching {input}");
            var companyProfiles = new List<CompanyProfile>();
            for (var i = 0; i < companySearchResult?.Items?.Count; i++)
            {
                var companyNumber = companySearchResult?.Items?[i].CompanyNumber;
                if (companyNumber is null)
                {
                    continue;
                }
                var companyProfile = await GetCompanyProfile(companyNumber, apiKey);
                companyProfiles.Add(companyProfile);
            }

            Console.WriteLine($"Found {companyProfiles.Count} company profiles matching {input}");
            return (from resultItem in companySearchResult?.Items
                    select new CompanyLookupOutput
                    {
                        InputCompanyName = input,
                        CompanyName = resultItem.Title,
                        CompanyNumber = resultItem.CompanyNumber,
                        CompanyType = resultItem.CompanyType,
                        CompanyStatus = resultItem.CompanyStatus,
                        DateOfCreation = resultItem.DateOfCreation,
                        DateOfCessation = resultItem.DateOfCessation,
                        AddressLine1 = resultItem.Address?.AddressLine1,
                        AddressLine2 = resultItem.Address?.AddressLine2,
                        CareOf = resultItem.Address?.CareOf,
                        Country = resultItem.Address?.Country,
                        Locality = resultItem.Address?.Locality,
                        PoBox = resultItem.Address?.PoBox,
                        PostalCode = resultItem.Address?.PostalCode,
                        Region = resultItem.Address?.Region,
                        SICCodes = companyProfiles?.FirstOrDefault(x => x.CompanyNumber == resultItem.CompanyNumber)?.SicCodes
                    }).ToList();
        }

        public static async Task<CompanySearchResult> SearchCompanies(string input, string apiKey)
        {
            var httpClient = new HttpClient();
            var url = $"https://api.company-information.service.gov.uk/search/companies?q={input}&items_per_page=3";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiKey}:")));
            var response = await httpClient.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = new CompanySearchResult();
            if (responseContent is not null)
            {
                result = JsonConvert.DeserializeObject<CompanySearchResult>(responseContent);
            }

            result ??= new CompanySearchResult();
            
            return result;
        }

        public static async Task<CompanyProfile> GetCompanyProfile(string companyNumber, string apiKey)
        {
            var httpClient = new HttpClient();
            var url = $"https://api.company-information.service.gov.uk/company/{companyNumber}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiKey}:")));
            var response = await httpClient.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<CompanyProfile>(responseContent);
            
            return result;
        }   
    }
}
