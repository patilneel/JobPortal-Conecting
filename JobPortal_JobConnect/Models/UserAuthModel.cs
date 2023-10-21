using System.ComponentModel.DataAnnotations;
namespace JobPortal_JobConnect.Models
{
   

    public class UserAuthModel
    {
        [Required]
        public string UserAuthName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string UserAuthPassword { get; set; }
    }

}
