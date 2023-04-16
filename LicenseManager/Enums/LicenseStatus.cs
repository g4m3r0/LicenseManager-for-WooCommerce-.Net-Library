namespace LicenseManagerClient.Lib.Enums
{
    /// <summary>
    /// Represents the status of a license.
    /// </summary>
    public enum LicenseStatus
    {
        /// <summary>
        /// The license has been sold.
        /// </summary>
        Sold = 1,

        /// <summary>
        /// The license has been delivered.
        /// </summary>
        Delivered = 2,

        /// <summary>
        /// The license is active.
        /// </summary>
        Active = 3,

        /// <summary>
        /// The license is inactive.
        /// </summary>
        Inactive = 4,
    }
}