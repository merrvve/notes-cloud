namespace nc2.Models
{
    public class User : BaseEntity
    {
        public string? uid { get; set; }

        public string? email { get; set; }
        public string? displayName { get; set; }
        public string? photoURL { get; set; }
        public Boolean? emailVerified { get; set; }

        public Boolean? isLoggedin { get; set; }

        //Relational
        public ICollection<UserNotebook>? userNotebooks { get; set; }
        public ICollection<UserCloud>? userClouds { get; set; }
    }
}
