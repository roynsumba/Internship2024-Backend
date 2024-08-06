using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppraisalTracker.Modules.AppraisalActivity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppraisalTracker.Data;
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
        [HttpGet("get-all-implementations")]
        public async Task<ActionResult<List<Implementation>>> GetImplementations()
        {
            var implementation = await _appraisalActivityService.FetchImplementations();
            return Ok(implementation);
        }

        // GET: api/Implementations/5
        [HttpGet("get-one-implementation")]
        public async Task<Implementation> FetchImplementation(int id)
        {
            var implementation = await _appraisalActivityService.FetchImplementation(id);
            return implementation;
        }

        // PUT: api/Implementations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("update-an-implementation")]
        public async Task<Implementation> UpdateImplementation([FromBody] Implementation implementation)
        {
            return await _appraisalActivityService.UpdateImplementation(implementation);

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
                return NotFound("Evidence details are incomplete.");
            }

            return File(filedetails.Evidence, filedetails.EvidenceContentType, filedetails.EvidenceFileName);
        }
    



    // DELETE: api/Implementations/5
    [HttpDelete("delete-an-implementation")]
        public async Task<ActionResult> DeleteImplementation(int id)
        {
            bool result = await _appraisalActivityService.DeleteImplementation(id);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound(new { message = "Implementation not found" });
            }
        }
    }
}
