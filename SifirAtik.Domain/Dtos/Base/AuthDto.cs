using System.Text.Json.Serialization;

namespace SifirAtik.Domain.Dtos.Base
{
    public class AuthDto
    {
        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("Password")]
        public string Password { get; set; }
    }
}
