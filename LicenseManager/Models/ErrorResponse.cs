namespace LicenseManager.Lib.Models
{
    using System.Text.Json.Serialization;

    public class ErrorResponse
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("data")]
        public ErrorData Data { get; set; }

        public class ErrorData
        {
            [JsonPropertyName("status")]
            public int Status { get; set; }
        }
    }
}
