using System;
using System.Threading.Tasks;
using LicenseManager.Models;

namespace LicenseManager
{
    public class LicenseManager
    {
        private readonly RequestHelper _requestHelper;
        private readonly SerializeHelper _serializeHelper;

        /// <summary>
        /// Create a new license manager
        /// </summary>
        /// <param name="host">Your wordpress host address (e.g. https://domain.com).</param>
        /// <param name="consumerKey">Your API consumer key.</param>
        /// <param name="consumerSecret">Your API consumer secret.</param>
        /// <param name="verifyHardwareId">Choose if the hardware id should be verified.</param>
        public LicenseManager(string host, string consumerKey, string consumerSecret)
        {
            _requestHelper = new(host, consumerKey, consumerSecret);
            _serializeHelper = new();
        }

        /// <summary>
        /// Activate license key. (TimesActivated will be increased if successful)
        /// </summary>
        /// <param name="licenseKey"></param>
        /// <param name="productId"></param>
        /// <returns>Success: True if license was activated, Message: Error message</returns>
        public async Task<(bool, string)> ActivateLicenseAsync(string licenseKey, string productId)
        {
            LicenseModel license;
            var (jsonString, error) = await _requestHelper.GetLicenseJsonAsync(licenseKey, Enums.RequestTypeEnum.Activate);

            if (error != null)
                return (false, error);

            try
            {
                license = _serializeHelper.Deserialize(jsonString);
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }

            return CheckLicenseResponse(license, licenseKey, productId);
        }

        /// <summary>
        /// Validate license key.
        /// </summary>
        /// <param name="licenseKey"></param>
        /// <param name="productId"></param>
        /// <returns>Success: True if license was activated, Message: Error message</returns>
        public async Task<(bool, string)> ValidateLicenseAsync(string licenseKey, string productId)
        {
            LicenseModel license;
            var (jsonString, error) = await _requestHelper.GetLicenseJsonAsync(licenseKey, Enums.RequestTypeEnum.Validate);

            if (error != null)
                return (false, error);

            try
            {
                license = _serializeHelper.Deserialize(jsonString);
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }

            return CheckLicenseResponse(license, licenseKey, productId);
        }

        private static (bool, string) CheckLicenseResponse(LicenseModel license, string licenseKey, string productId)
        {
            if (license == null)
                return (false, "License is null.");

            if (license.Data.LicenseKey != licenseKey)
                return (false, "License not matching.");

            if (license.Data.ProductId != productId)
                return (false, "ProductId not matching.");

            if (license.Data.TimesActivated > license.Data.TimesActivatedMax)
                return (false, "TimesActivated > TimesActivatedMax");

            if (!license.Success)
                return (false, "Not successful.");

            return (true, null);
        }
    }
}
