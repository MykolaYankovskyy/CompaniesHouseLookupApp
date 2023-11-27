using CompaniesHouseLookup.Models;
using Newtonsoft.Json;
using System.Text;
using System.Linq;

namespace CompaniesHouseLookup.Services
{
    public class CompaniesHouseLookupService()
    {
        public async Task<List<CompanyLookupOutput>> GetCompanyDetails(string input, string apiKey)
        {
            var httpClient = new HttpClient();
            var url = $"https://api.company-information.service.gov.uk/search/companies?q={input}&items_per_page=3";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiKey}:")));
            var response = await httpClient.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CompanySearchResult>(responseContent);
            return (from resultItem in result?.Items
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
                        Region = resultItem.Address?.Region
                    }).ToList();
        }
    }
}
