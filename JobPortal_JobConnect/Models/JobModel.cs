using System;
using System.ComponentModel.DataAnnotations;
namespace JobPortal_JobConnect.Models
{
   
    public class JobModel
    {
        public int JobId { get; set; }

        [Required]
        [MaxLength(100)]
        public string JobTitle { get; set; }

        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(5000)]
        public string JobDescription { get; set; }

        [Required]
        [MaxLength(50)]
        public string JobLocation { get; set; }

        [Required]
        [Range(0, Double.MaxValue, ErrorMessage = "Salary must be a positive number.")]
        public decimal Salary { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PostedDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ApplicationDeadline { get; set; }
    }

}
