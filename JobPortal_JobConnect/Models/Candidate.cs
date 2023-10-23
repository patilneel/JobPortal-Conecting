using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace JobPortal_JobConnect.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }

        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        
        public string Email { get; set; }

        
        public string ResumeFile { get; set; }

        public DateTime ApplicationDate { get; set; }
    }

    public class CandidateValidator : AbstractValidator<Candidate>
    {
        public CandidateValidator()
        {
            RuleFor(candidate => candidate.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(candidate => candidate.LastName).NotEmpty().MaximumLength(50);
            RuleFor(candidate => candidate.Email).NotEmpty().EmailAddress();
            RuleFor(candidate => candidate.ResumeFile).NotEmpty().MaximumLength(100);
        }
    }
}
