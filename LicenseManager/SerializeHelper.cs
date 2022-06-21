using System;
using System.Text.Json;
using LicenseManager.Models;

namespace LicenseManager
{
    public class SerializeHelper
    {
        private readonly JsonSerializerOptions _serializerOptions;

        public SerializeHelper()
        {
            this._serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public LicenseModel Deserialize(string jsonString)
        {
            return JsonSerializer.Deserialize<LicenseModel>(jsonString, _serializerOptions);
        }
    }
}
