namespace LicenseManager.Lib.JsonConverter
{
    using System;
    using System.Globalization;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a custom JSON converter for <see cref="DateTime"/> objects.
    /// </summary>
    public class CustomDateTimeJsonConverter : JsonConverter<DateTime?>
    {
        private const string DateTimeFormat = @"yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// Reads and converts the JSON to a <see cref="DateTime"/> object.
        /// </summary>
        /// <param name="reader">The reader to read the JSON from.</param>
        /// <param name="typeToConvert">The type to convert the JSON to.</param>
        /// <param name="options">The options to use while reading.</param>
        /// <returns>A <see cref="DateTime"/> object.</returns>
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string dateAsString = reader.GetString();

            if (string.IsNullOrEmpty(dateAsString))
            {
                return null;
            }

            return DateTime.ParseExact(
                dateAsString,
                DateTimeFormat,
                CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Writes a <see cref="DateTime"/> object as JSON.
        /// </summary>
        /// <param name="writer">The writer to write the JSON to.</param>
        /// <param name="dateTimeValue">The <see cref="DateTime"/> value to convert.</param>
        /// <param name="options">The options to use while writing.</param>
        public override void Write(Utf8JsonWriter writer,DateTime? dateTimeValue, JsonSerializerOptions options)
        {
            if (dateTimeValue.HasValue)
            {
                writer.WriteStringValue(
                    dateTimeValue.Value.ToString(
                    DateTimeFormat,
                    CultureInfo.InvariantCulture));
            }
            else
            {
                writer.WriteNullValue();
            }
        }
    }
}
