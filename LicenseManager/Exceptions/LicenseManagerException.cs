namespace LicenseManager.Lib.Exceptions
{
    using System;

    public class LicenseManagerException : Exception
    {
        public LicenseManagerException(string message)
            : base(message)
        {
        }
    }
}
