using System;
using System.ComponentModel.DataAnnotations;

namespace JobPortal_JobConnect.Models
{
  
    public class Application
    {
        public int ApplicationId { get; set; }

        [Required]
        public int JobId { get; set; }

        [Required]
        [StringLength(100)]
        public string CandidateName { get; set; }

        [Required]
        [EmailAddress]
        public string CandidateEmail { get; set; }

        [Required]
        public string ResumeFile { get; set; }

        public DateTime ApplicationDate { get; set; }
    }

}
