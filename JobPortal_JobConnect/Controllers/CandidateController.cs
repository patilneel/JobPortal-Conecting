using JobPortal_JobConnect.Models;
using JobPortal_JobConnect.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal_JobConnect.Controllers
{
    [Route("api/candidates")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Candidate>> GetCandidates()
        {
            var candidates = _candidateService.GetCandidates();
            return Ok(candidates);
        }

        [HttpGet("{candidateId}")]
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
        public ActionResult CreateCandidate(Candidate candidate)
        {
            _candidateService.CreateCandidate(candidate);
            return Ok("Candidate created successfully");
        }
    }

}
