using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CleanArt.Infrastructure.Authentication.Models
{
    public sealed class CredentialRepresentationModel
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("userLabel")]
        public string? UserLabel { get; set; }

        [JsonPropertyName("createdDate")]
        public long? CreatedDate { get; set; }

        [JsonPropertyName("secretData")]
        public string? SecretData { get; set; }

        [JsonPropertyName("credentialData")]
        public string? CredentialData { get; set; }

        [JsonPropertyName("priority")]
        public int? Priority { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }

        [JsonPropertyName("temporary")]
        public bool? Temporary { get; set; }

        public static CredentialRepresentationModel CreatePassword(string password, bool temporary = false) =>
            new()
            {
                Type = "password",
                Value = password,
                Temporary = temporary
            };
    }
}
