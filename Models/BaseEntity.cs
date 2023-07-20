namespace nc2.Models
{
    public class BaseEntity
    {
        public int id { get; set; }
        public DateTime? createdDate { get; set; } 
        public DateTime? modifiedDate { get; set; }
    }
}
