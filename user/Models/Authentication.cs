using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Authentication
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
