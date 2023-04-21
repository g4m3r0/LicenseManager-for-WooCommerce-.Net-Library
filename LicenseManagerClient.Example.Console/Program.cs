namespace LicenseManagerClient.Example.Console;

using System;
using System.Globalization;
using System.Reflection;
using LicenseManagerClient.Lib;
using LicenseManagerClient.Lib.Enums;
using LicenseManagerClient.Lib.Models;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("LicenseManagerClient Hello World!");

        var baseUrl = "https://licensemanager.codelu.eu";

        // Read Only
        //var consumerKey = "ck_252ce48bf36f3aacee112e3922fc90abf88efd38";
        //var consumerSecret = "cs_0474a2f6605b8bcb2ec3a3c9d8d934b3fed24325";

        //Read + Write
        var consumerKey = "ck_a0625b314db9ab7f44d4c29ac93aab416aa8ef8e";
        var consumerSecret = "cs_37abbda659e5932b286546890322d2fd55e9e298";

        // The woocommerce product id
        var productId = 11;

        // Set the culture (language) of the checking messages
        var cultureInfo = new CultureInfo("en");
        //var cultureInfo = new CultureInfo("de");
        //var cultureInfo = new CultureInfo("es");
        //var cultureInfo = new CultureInfo("fr");
        //var cultureInfo = new CultureInfo("ru");
        //var cultureInfo = new CultureInfo("zh");

        Console.WriteLine("Setup the client...");
        var client = new LicenseManagerClient(baseUrl, consumerKey, consumerSecret, productId, cultureInfo);

        var licenseKey = "C124A123C412";


        // Activate and check a license
        // Checks if the license is valid for the current product
        ActivateAndCheckLicense(client, licenseKey);

        // Validate and check a license
        // Checks if the license is valid for the current product
        ValidateAndCheckLicense(client, licenseKey);

        // List all licenses
        ListAllLicenses(client);

        // Retrieve a license
        RetrieveSingleLicense(client, licenseKey);

        // Create a license
        CreateSingleLicense(client);

        // Update a license
        UpdateLicense(client, licenseKey);

        // Activate a license
        ActivateLicense(client, licenseKey);

        // Deactivate a license
        DeactivateLicense(client, licenseKey);

        // Validate a license
        ValidateLicense(client, licenseKey);

        // List all generators
        ListGenerators(client);

        // Retrieve specific generator
        RetrieveSingleGenerator(client, 1);

        // Create a generator
        CreateSingleGenerator(client);

        // Update a generator
        UpdateGenerator(client, 1);

        // Generate generator
        GeneratorGenerate(client, 1);

        // VALIDATE CUSTOMER LICENSES
        ValidateCustomerLicense(client, 1);

        // Products/ping
        ProductsPing(client);

        // Products/update
        ProductsUpdate(client, licenseKey);
    }

    public static void ListAllLicenses(LicenseManagerClient client)
    {
        Console.WriteLine("List all licenses:");
        var allLicensesResponse = client.ListLicensesAsync().Result;

        Console.WriteLine($"Success: {allLicensesResponse.Success}");

        foreach (var licence in allLicensesResponse.Data)
        {
            OutputObjectProperties(licence);
        }
    }

    public static void RetrieveSingleLicense(LicenseManagerClient client, string licenseKey)
    {
        Console.WriteLine("Retrieve a license");
        var licenseResponse = client.RetrieveLicenseAsync(licenseKey).Result;

        Console.WriteLine($"Success: {licenseResponse.Success}");
        OutputObjectProperties(licenseResponse.Data);
    }

    public static void CreateSingleLicense(LicenseManagerClient client)
    {
        // TODO not working
        // The license key could not be added to the database.
        // https://github.com/wpexpertsio/license-manager-woocommerce/blob/53791ed76f3fd41aaa31ee435b721c3c8ab488af/includes/api/v2/Licenses.php#L390

        Console.WriteLine("Create a license");

        var newLicense = new CreateLicense()
        {
            OrderId = 0,
            ProductId = 11,
            LicenseKey = "TEST-LICENSE", // Guid.NewGuid().ToString(),
            ExpiresAt = DateTime.Now + TimeSpan.FromDays(7),
            Status = LicenseStatus.Active,
            TimesActivatedMax = 10,
            UserId = 1,
        };

        var createLicenseResponse = client.CreateLicenseAsync(newLicense).Result;

        Console.WriteLine($"Success: {createLicenseResponse.Success}");
        OutputObjectProperties(createLicenseResponse.Data);
    }

    public static void UpdateLicense(LicenseManagerClient client, string licenseKey)
    {
        // TODO not working
        // The license key could not be updated

        Console.WriteLine("Update a license");
        var licenseKeyToUpdate = licenseKey;

        var newLicenseData = new CreateLicense()
        {
            OrderId = 0,
            ProductId = 11,
            LicenseKey = licenseKeyToUpdate,
            ExpiresAt = DateTime.Now + TimeSpan.FromDays(7),
            Status = LicenseStatus.Active,
            TimesActivatedMax = new Random().Next(1, 10000),
            UserId = 1,
        };

        var updateLicenseResponse = client.UpdateLicenseAsync(newLicenseData, licenseKeyToUpdate).Result;

        Console.WriteLine($"Success: {updateLicenseResponse.Success}");
        OutputObjectProperties(updateLicenseResponse.Data);
    }

    public static void ActivateLicense(LicenseManagerClient client, string licenseKey)
    {
        Console.WriteLine("Activate a license:");
        var activateLicenseResponse = client.ActivateLicenseAsync(licenseKey).Result;

        Console.WriteLine($"Success: {activateLicenseResponse.Success}");
        OutputObjectProperties(activateLicenseResponse.Data);
    }

    public static void ActivateAndCheckLicense(LicenseManagerClient client, string licenseKey)
    {
        Console.WriteLine("Activate a license:");
        var activateLicenseResponse = client.ActivateLicenseAsync(licenseKey).Result;

        Console.WriteLine($"Success: {activateLicenseResponse.Success}");
        OutputObjectProperties(activateLicenseResponse.Data);

        Console.WriteLine("Check response:");
        var checkResponse = client.CheckLicenseActivation(activateLicenseResponse, licenseKey);
        OutputObjectProperties(checkResponse);
    }

    public static void DeactivateLicense(LicenseManagerClient client, string licenseKey)
    {
        Console.WriteLine("Deactivate a license:");
        var licenseResponse = client.DeactivateLicenseAsync(licenseKey).Result;

        Console.WriteLine($"Success: {licenseResponse.Success}");
        OutputObjectProperties(licenseResponse.Data);
    }

    public static void ValidateLicense(LicenseManagerClient client, string licenseKey)
    {
        // TODO product always null?

        Console.WriteLine("Validate a license:");
        var licenseResponse = client.ValidateLicenseAsync(licenseKey).Result;

        Console.WriteLine($"Success: {licenseResponse.Success}");
        OutputObjectProperties(licenseResponse.Data);
    }

    public static void ValidateAndCheckLicense(LicenseManagerClient client, string licenseKey)
    {
        Console.WriteLine("Validate a license:");
        var licenseResponse = client.ValidateLicenseAsync(licenseKey).Result;

        Console.WriteLine($"Success: {licenseResponse.Success}");
        OutputObjectProperties(licenseResponse.Data);

        Console.WriteLine("Check response:");
        var checkResponse = client.CheckLicenseValidation(licenseResponse, licenseKey);
        OutputObjectProperties(checkResponse);
    }

    public static void ListGenerators(LicenseManagerClient client)
    {
        Console.WriteLine("List all generators:");
        var allGenaratorsResponse = client.ListGeneratorsAsync().Result;

        Console.WriteLine($"Success: {allGenaratorsResponse.Success}");

        foreach (var generator in allGenaratorsResponse.Data)
        {
            OutputObjectProperties(generator);
        }
    }

    public static void RetrieveSingleGenerator(LicenseManagerClient client, int generatorId)
    {
        Console.WriteLine("Retrieve a Generator");
        var generatorResponse = client.RetrieveGeneratorAsync(generatorId).Result;

        Console.WriteLine($"Success: {generatorResponse.Success}");
        OutputObjectProperties(generatorResponse.Data);
    }

    public static void CreateSingleGenerator(LicenseManagerClient client)
    {
        Console.WriteLine("Create a Generator");

        var newGenerator = new CreateGenerator()
        {
            Name = "Test Generator",
            Charset = "LICENSE_GENERATE",
            Chunks = 7,
            ChunkLength = 2,
            TimesActivatedMax = 10,
            Separator = "-",
            Prefix = "PRE",
            Suffix = "SUFFIX",
            ExpiresIn = 10
        };

        var createResponse = client.CreateGeneratorAsync(newGenerator).Result;

        Console.WriteLine($"Success: {createResponse.Success}");
        OutputObjectProperties(createResponse.Data);
    }

    public static void UpdateGenerator(LicenseManagerClient client, int generatorId)
    {
        Console.WriteLine("Update a Generator");

        var updatedGenerator = new CreateGenerator()
        {
            Name = "Test Generator",
            Charset = "LICENSE_GENERATE",
            Chunks = 7,
            ChunkLength = 2,
            TimesActivatedMax = 10,
            Separator = "-",
            Prefix = "PRE",
            Suffix = "SUFFIX",
            ExpiresIn = 10
        };

        var updateResponse = client.UpdateGeneratorAsync(updatedGenerator, generatorId).Result;

        Console.WriteLine($"Success: {updateResponse.Success}");
        OutputObjectProperties(updateResponse.Data);
    }

    public static void GeneratorGenerate(LicenseManagerClient client, int generatorId)
    {
        // TODO not working
        // seems like its not implemented by the WP plugin and the documentation is just wrong
        // No route was found matching the URL and request method

        Console.WriteLine("Generate License Keys");

        var generate = new GeneratorGenerate()
        {
            Amount = 10,
            Save = true,
            Status = LicenseStatus.Active,
            OrderId = null,
            ProductId = 16,
            UserId = 1,
        };

        var generateResponse = client.GenerateGeneratorAsync(generate, generatorId).Result;

        Console.WriteLine($"Success: {generateResponse.Success}");

        foreach (var license in generateResponse.Data)
        {
            Console.WriteLine(license);
        }
    }

    public static void ValidateCustomerLicense(LicenseManagerClient client, int customerId)
    {
        // TODO not working
        // Maybe only available for PRO?
        // No route was found matching the URL and request method

        Console.WriteLine("Validate customer license");
        var licenseResponse = client.ValidateCustomerLicensesAsync(customerId).Result;

        Console.WriteLine($"Success: {licenseResponse.Success}");
        OutputObjectProperties(licenseResponse.Data);
    }

    public static void ProductsPing(LicenseManagerClient client)
    {
        // TODO not working
        // Maybe only available for PRO?
        // No route was found matching the URL and request method

        Console.WriteLine("Ping (test communication)");

        var pingRequest = new PingRequest()
        {
            LicenseKey = "Test",
            ProductName = "Test",
            Host = "localhost",
        };

        var response = client.ProductsPingAsync(pingRequest).Result;

        Console.WriteLine($"Success: {response.Success}");
        OutputObjectProperties(response.Data);
    }

    public static void ProductsUpdate(LicenseManagerClient client, string licenseKey)
    {
        // TODO not working
        // Maybe only available for PRO?
        // No route was found matching the URL and request method

        Console.WriteLine("List product assigned to key");

        var response = client.ProductsUpdateAsync(licenseKey).Result;

        Console.WriteLine($"Success: {response.Success}");
        OutputObjectProperties(response.Data);
    }

    public static void OutputObjectProperties(object obj)
    {
        if (obj == null)
        {
            Console.WriteLine("Object is null.");
            return;
        }

        Type type = obj.GetType();
        PropertyInfo[] properties = type.GetProperties();

        Console.WriteLine("Properties of object (Type: {0}):", type.Name);

        foreach (PropertyInfo property in properties)
        {
            // Check if the property has index parameters
            if (property.GetIndexParameters().Length == 0)
            {
                Console.WriteLine("  {0}: {1}", property.Name, property.GetValue(obj));
            }
            else
            {
                Console.WriteLine("  {0}: Ignored (indexed property)", property.Name);
            }
        }
    }
}