using System.Text.Json.Serialization;

namespace nc2.Models
{
    public class UserCloud : BaseEntity
    {
        public int cloudId { get; set; }

        public int userId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }

        [JsonIgnore]
        public Cloud? Cloud { get; set; }
    }
}
