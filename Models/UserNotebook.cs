using System.Text.Json.Serialization;

namespace nc2.Models
{
    public class UserNotebook : BaseEntity
    {

        public int notebookId { get; set; }

        public int userId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }

        [JsonIgnore]
        public Notebook? Notebook { get; set; }
    }
}
