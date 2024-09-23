using ProductAPI.Enums;

namespace ProductAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public SystemRole SystemRole { get; set; }
    }
}
