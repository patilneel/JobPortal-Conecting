using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace JobPortal_JobConnect.Models
{
   

    public class UserAuthModel: IdentityUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserAuthName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string UserAuthPassword { get; set; }
    }

}
