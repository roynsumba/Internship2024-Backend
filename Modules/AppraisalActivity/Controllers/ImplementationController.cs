using AppraisalTracker.Modules.AppraisalActivity.Models;
using Microsoft.AspNetCore.Mvc;
using AppraisalTracker.Modules.AppraisalActivity.Services;

namespace AppraisalTracker.Modules.AppraisalActivity.Controllers
{
    [Route("api/Implementations")]
    [ApiController]
    public class ImplementationController : ControllerBase
    {
        private readonly IAppraisalActivityService _appraisalActivityService;

        public ImplementationController(IAppraisalActivityService appraisalActivityService)
        {
            _appraisalActivityService = appraisalActivityService;
        }

        // GET: api/Implementations
        [HttpGet("get-all-implementations/{userId}")]
        public async Task<ActionResult<List<ImplementationViewModel>>> GetImplementations([FromRoute] Guid userId)
        {
            var implementation = await _appraisalActivityService.FetchImplementations(userId);
            return Ok(implementation);
        }

        // GET: api/Implementations/5
        [HttpGet("get-one-implementation")]
        public async Task<Implementation> FetchImplementation(Guid Id)
        {
            var implementation = await _appraisalActivityService.FetchImplementation(Id);
            return implementation;
        }

        // PUT: api/Implementations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("update-an-implementation")]
        public async Task<ImplementationViewModel> UpdateImplementation([FromForm] ImplementationCreateModel implementation, Guid id)
        {
            return await _appraisalActivityService.UpdateImplementation(implementation,id);

        }

        // POST: api/Implementations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("create-an-implementation")]
        public async Task<ImplementationViewModel> AddImplementation([FromForm] ImplementationCreateModel implementation)
        {


            return await _appraisalActivityService.AddImplementation(implementation);
        }


        [HttpGet("get-evidence-file")]
        public async Task<IActionResult> FetchEvidenceFile(Guid id)
        {
            var filedetails = await _appraisalActivityService.FetchEvidence(id);
            if (filedetails.Evidence == null || string.IsNullOrEmpty(filedetails.EvidenceContentType) || string.IsNullOrEmpty(filedetails.EvidenceFileName))
            {
                return NotFound("Evidence not found");
            }

            return File(filedetails.Evidence, filedetails.EvidenceContentType, filedetails.EvidenceFileName);
        }




        // DELETE: api/Implementations/5
        [HttpDelete("delete-an-implementation")]
        public async Task<ActionResult<ImplementationViewModel>> DeleteImplementation(Guid Id)
        {
            var result = await _appraisalActivityService.DeleteImplementation(Id);
            if (result != null)
            {
                return result;
            }
            else
            {
                return NotFound(new { message = "Implementation not found" });
            }
        }

        [HttpGet("all-implementations-for-single-activity/{measurableActivityId}")]
        public async Task<ActionResult<List<Implementation>>> GetImplementationsForASingleActivity([FromRoute] Guid measurableActivityId)
        {
            var implementations = await _appraisalActivityService.GetImplementationsForASingleActivity(measurableActivityId);
            return Ok(implementations);
        }
    }
}
