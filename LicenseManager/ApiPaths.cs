namespace LicenseManagerClient.Lib
{
    public static class ApiPaths
    {
        public const string Licenses = "/wp-json/lmfwc/v2/licenses";
        public static string LicenseByKey(string licenseKey) => $"/wp-json/lmfwc/v2/licenses/{licenseKey}";

        public static string DeactivateLicense(string licenseKey) => $"/wp-json/lmfwc/v2/licenses/deactivate/{licenseKey}";

        public static string ValidateLicense(string licenseKey) => $"/wp-json/lmfwc/v2/licenses/validate/{licenseKey}";
        public static string ListAllGenerators() => "/wp-json/lmfwc/v2/generators";
        public static string GetGeneratorById(int generatorId) => $"/wp-json/lmfwc/v2/generators/{generatorId}";
        public static string CreateGenerator => "/wp-json/lmfwc/v2/generators";

    }
}
