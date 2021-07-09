using System.Text.Json.Serialization;

namespace Willcord.Services.Common
{
    public class AwsConfig
    {
        [JsonPropertyName("accessKey")]
        public string AccessKey { get; set; }

        [JsonPropertyName("secretKey")]
        public string SecretKey { get; set; }
    }
}