using System.Text;
using System.Management;
using System.Security.Cryptography;

namespace LicenseManager
{
    public static class HardwareId
    {
        /// <summary>
        /// Get the computers unique hardware id.
        /// </summary>
        /// <returns>String: hashed hardware id.</returns>
        public static string GetHardwareId()
        {
            return Sha256Hash(GetBaseId() + GetCpuId());
        }

        /// <summary>
        /// Calculate sha256 hash of a string.
        /// </summary>
        private static string Sha256Hash(string textToHash)
        {
            var crypt = SHA256.Create();
            var hash = string.Empty;
            var byteArray = crypt.ComputeHash(Encoding.ASCII.GetBytes(textToHash));

            foreach (var b in byteArray)
            {
                hash += b.ToString("x2");
            }

            return hash;
        }

        private static ManagementObject GetSysObject(string wmiClass)
        {
            try
            {
                using var enumerator = new ManagementClass(wmiClass).GetInstances().GetEnumerator();

                if (enumerator.MoveNext())
                    return (ManagementObject)enumerator.Current;
            } catch {
                //ignore error
            }
            return null;
        }

        private static string GetSysObjectData(ref ManagementObject obj, string wmiProperty)
        {
            try
            {
                var obj1 = obj[wmiProperty];
                return obj1 == null ? string.Empty : obj1.ToString().Trim();
            } catch {
                //ignore error
            }
            return null;
        }

        /// <summary>
        /// Get the computers board id's.
        /// </summary>
        private static string GetBaseId()
        {
            var sysObject = HardwareId.GetSysObject("Win32_BaseBoard");
            return GetSysObjectData(ref sysObject, "Model") + GetSysObjectData(ref sysObject, "Manufacturer") + GetSysObjectData(ref sysObject, "Name") + GetSysObjectData(ref sysObject, "SerialNumber");
        }
        /// <summary>
        /// Get the computers cpu name and id.
        /// </summary>
        private static string GetCpuId()
        {
            var sysObject = GetSysObject("Win32_Processor");
            return GetSysObjectData(ref sysObject, "Name") + GetSysObjectData(ref sysObject, "ProcessorId");
        }
    }
}
