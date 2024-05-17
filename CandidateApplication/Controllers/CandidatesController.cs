using CandidateApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace CandidateApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService ?? throw new ArgumentNullException(nameof(candidateService));
        }

        [HttpPost]
        public async Task<IActionResult> SubmitApplication([FromBody] CandidateDTO candidateDto)
        {
            if (candidateDto == null)
            {
                return BadRequest("Candidate data is missing.");
            }

            try
            {
                var createdCandidate = await _candidateService.CreateCandidateAsync(candidateDto);
                return CreatedAtAction(nameof(SubmitApplication), new { id = createdCandidate.CandidateID }, createdCandidate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
