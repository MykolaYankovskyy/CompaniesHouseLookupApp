using CompaniesHouseLookup.Models;
using Newtonsoft.Json;
using System.Text;
using System.Linq;

namespace CompaniesHouseLookup.Services
{
    public class CompaniesHouseLookupService()
    {
        public async Task<List<CompanyLookupOutput>> GetCompanyDetails(string input)
        {
            var httpClient = new HttpClient();
            var url = $"https://api.company-information.service.gov.uk/search/companies?q={input}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes("67b05c4b-6361-464f-a2b2-7b1e62b41d23:")));
            var response = await httpClient.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CompanySearchResult>(responseContent);
            return (from resultItem in result?.Items
                    select new CompanyLookupOutput
                    {
                        InputCompanyName = input,
                        CompanyName = resultItem.Title,
                        CompanyNumber = resultItem.CompanyNumber
                    }).ToList();
        }
    }
}
