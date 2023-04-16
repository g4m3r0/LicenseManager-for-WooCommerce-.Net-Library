namespace LicenseManagerClient.Example.Console;

using System;
using System.Reflection;
using LicenseManagerClient.Lib;
using LicenseManagerClient.Lib.Enums;
using LicenseManagerClient.Lib.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("LicenseManagerClient Hello World!");

        var baseUrl = "https://licensemanager.codelu.eu";

        // Read Only
        //var consumerKey = "ck_252ce48bf36f3aacee112e3922fc90abf88efd38";
        //var consumerSecret = "cs_0474a2f6605b8bcb2ec3a3c9d8d934b3fed24325";

        //Read + Write
        var consumerKey = "ck_a0625b314db9ab7f44d4c29ac93aab416aa8ef8e";
        var consumerSecret = "cs_37abbda659e5932b286546890322d2fd55e9e298";

        Console.WriteLine("Setup the client...");
        var client = new LicenseManagerClient(baseUrl, consumerKey, consumerSecret);

        var licenseKey = "C124A123C412";

        // List all licenses
        ListAllLicenses(client);

        // Retrieve a license
        //RetriveSingleLicense(client, licenseKey);

        // Create a license
        //CreateSingleLicense(client);

        // Update a license
        //UpdateLicense(client, licenseKey);

        // Activate a license
        //ActivateLicense(client, licenseKey);

        // Deactivate a license
        //DeactivateLicense(client, licenseKey);

        // Validate a license
        //ValidateLicense(client, licenseKey);

        // List all generators
        ListGenerators(client);

        // Retrieve specific generator

        // Create a generator

        // Update a generator

        // Generate generator

        // VALIDATE CUSTOMER LICENSES

        // Products/ping

        // Products/update
    }

    public static void ListAllLicenses(LicenseManagerClient client)
    {
        Console.WriteLine("List all licenses:");
        var allLicensesResponse = client.ListLicenses().Result;

        Console.WriteLine($"Success: {allLicensesResponse.Success}");

        foreach (var licence in allLicensesResponse.Data)
        {
            OutputObjectProperties(licence);
        }
    }

    public static void RetriveSingleLicense(LicenseManagerClient client, string licenseKey)
    {
        Console.WriteLine("Retrieve a license");    
        var licenseResponse = client.RetrieveLicense(licenseKey).Result;

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

        var createLicenseResponse = client.CreateLicense(newLicense).Result;

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

        var updateLicenseResponse = client.UpdateLicense(newLicenseData, licenseKeyToUpdate).Result;

        Console.WriteLine($"Success: {updateLicenseResponse.Success}");
        OutputObjectProperties(updateLicenseResponse.Data);
    }

    public static void ActivateLicense(LicenseManagerClient client, string licenseKey)
    {
        Console.WriteLine("Activate a license:");
        var activateLicenseResponse = client.ActivateLicense(licenseKey).Result;

        Console.WriteLine($"Success: {activateLicenseResponse.Success}");
        OutputObjectProperties(activateLicenseResponse.Data);
    }

    public static void DeactivateLicense(LicenseManagerClient client, string licenseKey)
    {
        Console.WriteLine("Deactivate a license:");
        var licenseResponse = client.DeactivateLicense(licenseKey).Result;

        Console.WriteLine($"Success: {licenseResponse.Success}");
        OutputObjectProperties(licenseResponse.Data);
    }

    public static void ValidateLicense(LicenseManagerClient client, string licenseKey)
    {
        // TODO product always null?

        Console.WriteLine("Validate a license:");
        var licenseResponse = client.ValidateLicense(licenseKey).Result;

        Console.WriteLine($"Success: {licenseResponse.Success}");
        OutputObjectProperties(licenseResponse.Data);
    }

    public static void ListGenerators(LicenseManagerClient client)
    {
        Console.WriteLine("List all generators:");
        var allGenaratorsResponse = client.ListGenerators().Result;

        Console.WriteLine($"Success: {allGenaratorsResponse.Success}");

        foreach(var generator in allGenaratorsResponse.Data)
        {
            OutputObjectProperties(generator);
        }
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