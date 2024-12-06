using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Authenticate
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }
    }
}