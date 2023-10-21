using JobPortal_JobConnect.Models;
using JobPortal_JobConnect.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal_JobConnect.Controllers
{
    [Route("api/applications")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Application>> GetApplications()
        {
            var applications = _applicationService.GetApplications();
            return Ok(applications);
        }

        [HttpGet("{applicationId}")]
        public ActionResult<Application> GetApplication(int applicationId)
        {
            var application = _applicationService.GetApplication(applicationId);
            if (application == null)
            {
                return NotFound();
            }
            return Ok(application);
        }

        [HttpPost]
        public ActionResult ApplyForJob(Application application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _applicationService.ApplyForJob(application);
            return Ok("Application submitted successfully");
        }
    }


}
