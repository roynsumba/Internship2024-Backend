using AppraisalTracker.Exceptions;
using AppraisalTracker.Modules.AppraisalActivity.Models;
using AppraisalTracker.Modules.AppraisalActivity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppraisalTracker.Modules.AppraisalActivity.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IAppraisalActivityService _appraisalActivityService;

        public ActivityController(IAppraisalActivityService appraisalActivityService)
        {
            _appraisalActivityService = appraisalActivityService;

        }

        // 1. Create an activity
        [HttpPost("activity")]
        public async Task<ActionResult<MeasurableActivity>> CreateActivity(MeasurableActivity activity)
        {
            return await _appraisalActivityService.PostMeasurableActivity(activity);
        }

        // 2. Reatrieve all activities
        [HttpGet("activities")]
        public async Task<ActionResult<List<MeasurableActivity>>> RetrieveAllActivities()
        {
            return await _appraisalActivityService.FetchMeasurableActivities();
        }

        // 3.Retrieve details of a single activity by activity Id.
        [HttpGet("activity/{id}")]
        public async Task<ActionResult<MeasurableActivity>> RetrieveSingleActivity(int id)
        {
            try
            {
                var activity = await _appraisalActivityService.FetchMeasurableActivity(id);
                return Ok(activity);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = "Activity not found" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", detail = ex.Message });
            }
        }


        // 4. Update for an activity 
        [HttpPut("activity/{id}")]
        public async Task<ActionResult<MeasurableActivity>> UpdateActivity(int id, MeasurableActivity measurableActivity)
        {
            if (id != measurableActivity.MeasurableActivityId)
            {
                return BadRequest(new { message = "Mismatched activity ID" });
            }

            try
            {
                var updatedActivity = await _appraisalActivityService.UpdateMeasurableActivity(id, measurableActivity);
                return Ok(updatedActivity);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = "Activity not found" });
            }
            catch (ClientFriendlyException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", detail = ex.Message });
            }
        }

        // 5. Delete a measurable activity
        [HttpDelete("activity/{id}")]
        public async Task<ActionResult<bool>> DeleteActivity(int id)
        {
            var success = await _appraisalActivityService.DeleteMeasurableActivity(id);
            if (success)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
