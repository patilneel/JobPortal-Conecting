using System;
using System.ComponentModel.DataAnnotations;

namespace JobPortal_JobConnect.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string ContactInfo { get; set; }

        [MaxLength(500)]
        public string Skills { get; set; }
        // Add other properties as needed
    }

}
