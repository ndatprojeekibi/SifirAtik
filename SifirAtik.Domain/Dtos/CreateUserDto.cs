﻿using SifirAtik.Domain.Dtos.Base;
using System.Text.Json.Serialization;

namespace SifirAtik.Domain.Dtos
{
    public class CreateUserDto : BaseDto
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Surname")]
        public string Surname { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("Address")]
        public string Address { get; set; }

        [JsonPropertyName("PhoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
