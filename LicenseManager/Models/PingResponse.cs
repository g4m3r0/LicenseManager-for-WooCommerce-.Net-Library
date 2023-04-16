namespace LicenseManagerClient.Lib.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a ping response.
    /// </summary>
    public class PingResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether the ping request was successful.
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the data returned by the ping request.
        /// </summary>
        [JsonPropertyName("data")]
        public object Data { get; set; }
    }
}
