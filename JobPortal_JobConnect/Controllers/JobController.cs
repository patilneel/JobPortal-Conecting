using JobPortal_JobConnect.Models;
using JobPortal_JobConnect.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal_JobConnect.Controllers
{
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    [Route("api/jobs")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")] // the CORS policy
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<JobModel>> GetJobListings()
        {
            var jobListings = _jobService.GetJobListings();
            return Ok(jobListings);
        }

        [HttpGet("{jobId}")]
        public ActionResult<JobModel> GetJobDetails(int jobId)
        {
            var jobDetails = _jobService.GetJobDetails(jobId);
            if (jobDetails == null)
            {
                return NotFound();
            }
            return Ok(jobDetails);
        }

        [HttpPost]
        public ActionResult CreateJob(JobModel job)
        {
            // Model validation will be automatically performed based on data annotations.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _jobService.CreateJob(job);
            return Ok("Job created successfully");
        }
    }

}
