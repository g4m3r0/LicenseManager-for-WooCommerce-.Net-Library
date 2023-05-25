namespace LicenseManager.Lib.Models
{
    /// <summary>
    /// Represents the response of a license check operation.
    /// </summary>
    public class LicenseCheckResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether the license check was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the message describing the result of the license check.
        /// </summary>
        public string Message { get; set; }
    }
}
