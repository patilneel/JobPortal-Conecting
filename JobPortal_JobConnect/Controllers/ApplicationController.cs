using JobPortal_JobConnect.Models;
using JobPortal_JobConnect.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;

namespace JobPortal_JobConnect.Controllers
{
    [Route("api/applications")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [SwaggerOperation("Get all applications")]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<Application>> GetApplications()
        {
            try
            {
                var applications = _applicationService.GetApplications();
                return Ok(applications);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{applicationId}")]
        [SwaggerOperation("Get an application by ID")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Application> GetApplication(int applicationId)
        {
            try
            {
                var application = _applicationService.GetApplication(applicationId);
                if (application == null)
                {
                    return NotFound();
                }
                return Ok(application);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        [SwaggerOperation("Apply for a job")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult ApplyForJob([FromBody] Application application)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _applicationService.ApplyForJob(application);
                return Created($"api/applications/{application.ApplicationId}", application);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{applicationId}")]
        [SwaggerOperation("Update an application")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult UpdateApplication(int applicationId, [FromBody] Application application)
        {
            try
            {
                if (applicationId != application.ApplicationId)
                {
                    return BadRequest("Application ID in the URL does not match the payload.");
                }

                var existingApplication = _applicationService.GetApplication(applicationId);
                if (existingApplication == null)
                {
                    return NotFound();
                }

                _applicationService.UpdateApplication(application);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{applicationId}")]
        [SwaggerOperation("Delete an application")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult DeleteApplication(int applicationId)
        {
            try
            {
                var existingApplication = _applicationService.GetApplication(applicationId);
                if (existingApplication == null)
                {
                    return NotFound();
                }

                _applicationService.DeleteApplication(applicationId);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
