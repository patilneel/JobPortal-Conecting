using FluentValidation;
using JobPortal_JobConnect.Models;


namespace JobPortal_JobConnect.Models

{
   
    public class JobModelValidator : AbstractValidator<JobModel>
    {
        public JobModelValidator()
        {
            RuleFor(job => job.JobTitle)
                .NotEmpty().WithMessage("Job title is required.")
                .MaximumLength(100).WithMessage("Job title cannot exceed 100 characters.");

            RuleFor(job => job.CompanyName)
                .NotEmpty().WithMessage("Company name is required.")
                .MaximumLength(100).WithMessage("Company name cannot exceed 100 characters.");

            RuleFor(job => job.JobDescription)
                .NotEmpty().WithMessage("Job description is required.")
                .MaximumLength(5000).WithMessage("Job description cannot exceed 5000 characters.");

            RuleFor(job => job.JobLocation)
                .NotEmpty().WithMessage("Job location is required.")
                .MaximumLength(50).WithMessage("Job location cannot exceed 50 characters.");

            RuleFor(job => job.Salary)
                .GreaterThan(0).WithMessage("Salary must be greater than 0.");

            RuleFor(job => job.PostedDate)
                .LessThan(DateTime.Now).WithMessage("Posted date cannot be in the future.");

            RuleFor(job => job.ApplicationDeadline)
                .GreaterThan(job => job.PostedDate).WithMessage("Application deadline must be after the posted date.");
        }
    }

}
