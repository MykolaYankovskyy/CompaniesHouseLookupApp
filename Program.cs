
using CompaniesHouseLookup.Models;
using CompaniesHouseLookup.Services;
using CsvHelper;

Console.WriteLine("Welcome to the Companies House Lookup App");
Console.WriteLine("Please upload a CSV file containing a list of company names to lookup.");
Console.WriteLine("Format of the CSV file should be as follows:");
Console.WriteLine("Company Name");
Console.WriteLine("Company 1");
Console.WriteLine("Company 2");

try
{
    Console.WriteLine("Please enter your Companies House API key:");
    var apiKey = Console.ReadLine();
    if (apiKey is null) throw new ArgumentNullException(nameof(apiKey));
    Console.WriteLine("Please enter the CSV file name:");
    var fileName = Console.ReadLine();
    if (fileName is null) throw new ArgumentNullException(nameof(fileName));

    Console.WriteLine("Processing file: " + fileName);

    if (!File.Exists($"./{fileName}"))
    {
        Console.WriteLine("File does not exist");
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
        return;
    }

    if (!fileName.EndsWith(".csv"))
    {
        Console.WriteLine("File is not a CSV file");
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
        return;
    }

    var csvConfig = new CsvHelper.Configuration.CsvConfiguration(System.Globalization.CultureInfo.CurrentCulture)
    {
        HasHeaderRecord = true,
        HeaderValidated = null,
        MissingFieldFound = null,
        Delimiter = ",",
        TrimOptions = CsvHelper.Configuration.TrimOptions.Trim,
        IgnoreBlankLines = true,
        BadDataFound = null,
        Encoding = System.Text.Encoding.UTF8
    };

    var companyLookupOutputs = new List<CompanyLookupOutput>();

    using var reader = new StreamReader($"./{fileName}");
    using var csv = new CsvReader(reader, csvConfig);
    {

        var records = csv.GetRecords<CompanyLookupInput>();

        var companiesHouseLookupService = new CompaniesHouseLookupService();

        foreach (var record in records)
        {
            if (string.IsNullOrWhiteSpace(record.CompanyName))
            {
                continue;
            }

            var companyDetails = await companiesHouseLookupService.GetCompanyDetails(record.CompanyName, apiKey);

            if (companyDetails.Any())
            {
                companyLookupOutputs.AddRange(companyDetails);
            }
        }
    }

    using var writer = new StreamWriter($"./{fileName.Replace(".csv", $"-output-{DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss")}.csv")}")
    {
        AutoFlush = true,
    };
    using var csvWriter = new CsvWriter(writer, csvConfig);
    {
        csvWriter.WriteRecords(companyLookupOutputs);
    }

    Console.WriteLine("Finished processing file: " + fileName);
    Console.WriteLine("Output file: " + fileName.Replace(".csv", $"-output-{DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss")}.csv"));
    Console.WriteLine("Press any key to exit");
    Console.ReadKey();
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred");
    Console.WriteLine(ex.Message);
    Console.WriteLine("Press any key to exit");
    Console.ReadKey();
}

