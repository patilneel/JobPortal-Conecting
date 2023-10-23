using System;
using System.Collections.Generic;
using JobPortal_JobConnect.Models;
using JobPortal_JobConnect.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using FluentValidation;

namespace JobPortal_JobConnect.Controllers
{
    [Route("api/candidates")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly IValidator<Candidate> _candidateValidator;

        public CandidateController(ICandidateService candidateService, IValidator<Candidate> candidateValidator)
        {
            _candidateService = candidateService;
            _candidateValidator = candidateValidator;
        }

        [HttpGet]
        [SwaggerOperation("GetCandidates")]
        public ActionResult<IEnumerable<Candidate>> GetCandidates()
        {
            var candidates = _candidateService.GetCandidates();
            return Ok(candidates);
        }

        [HttpGet("{candidateId}")]
        [SwaggerOperation("GetCandidate")]
        public ActionResult<Candidate> GetCandidate(int candidateId)
        {
            var candidate = _candidateService.GetCandidate(candidateId);
            if (candidate == null)
            {
                return NotFound();
            }
            return Ok(candidate);
        }

        [HttpPost]
        [SwaggerOperation("CreateCandidate")]
        public ActionResult CreateCandidate(Candidate candidate)
        {
            var validationResult = _candidateValidator.Validate(candidate);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            _candidateService.CreateCandidate(candidate);
            return Ok("Candidate created successfully");
        }

        [HttpPut("{candidateId}")]
        [SwaggerOperation("UpdateCandidate")]
        public ActionResult UpdateCandidate(int candidateId, Candidate candidate)
        {
            if (candidateId != candidate.CandidateId)
            {
                return BadRequest("CandidateId in the URL does not match the one in the request body.");
            }

            var validationResult = _candidateValidator.Validate(candidate);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var updatedCandidate = _candidateService.UpdateCandidate(candidate);
            if (updatedCandidate == null)
            {
                return NotFound("Candidate not found.");
            }

            return Ok("Candidate updated successfully");
        }

        [HttpDelete("{candidateId}")]
        [SwaggerOperation("DeleteCandidate")]
        public ActionResult DeleteCandidate(int candidateId)
        {
            var deleted = _candidateService.DeleteCandidate(candidateId);
            if (!deleted)
            {
                return NotFound("Candidate not found.");
            }

            return Ok("Candidate deleted successfully");
        }
    }
}
