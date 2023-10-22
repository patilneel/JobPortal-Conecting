using System.ComponentModel.DataAnnotations;
namespace JobPortal_JobConnect.Models
{
   
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        // Additional user properties, such as roles, added here and later stage if time permit
    }

}
