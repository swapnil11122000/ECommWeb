using System.ComponentModel.DataAnnotations;
namespace ECommWeb.Models
{
    public class Users
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public  string Email { get; set; }
        [Required]
        
        public int Mobile { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
