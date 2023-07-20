namespace nc2.Models.Dto
{
    public class LoginUserDto
    {
        public int id { get; set; }
        public string displayName { get; set; }
        public string token { get; set; }
        public int cloudId { get; set; }
        public int userId { get; set; }

        public Boolean isNew { get; set; }

    }
}
