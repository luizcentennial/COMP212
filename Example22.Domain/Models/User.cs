using System;
using System.Text;
using System.Text.Json.Serialization;

namespace Example22.Domain.Models {
    public class User {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastname")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("birthDate")]
        public DateTime BirthDate { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        public override string ToString() {
            StringBuilder builder = new StringBuilder();

            foreach (var property in typeof(User).GetProperties()) {
                builder.AppendLine($"{property.Name}: {property.GetValue(this)}");
            }

            return builder.ToString();
        }
    }
}
