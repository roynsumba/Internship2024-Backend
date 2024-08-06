using AppraisalTracker.Modules.AppraisalActivity.Models;
using Microsoft.AspNetCore.Mvc;
using AppraisalTracker.Modules.AppraisalActivity.Services;

namespace AppraisalTracker.Modules.AppraisalActivity.Controllers
{
    [Route("api/Measurable-Activities")]
    [ApiController]
    public class MeasurableActivityController : ControllerBase
    {
        private readonly IAppraisalActivityService _appraisalActivityService;
        public MeasurableActivityController(IAppraisalActivityService appraisalActivityService)
        {
            _appraisalActivityService = appraisalActivityService;
        }

        // GET: api/MeasurableActivities
        [HttpGet("get-all-measurable-activities")]
        public async Task<ActionResult<MeasurableActivityViewModel>> GetMeasurableActivities()
        {
            var measurableActivities = await _appraisalActivityService.FetchMeasurableActivities();
            return Ok(measurableActivities);
        }

        // GET: api/MeasurableActivities/5
        [HttpGet("get-a-measurable-activity")]
        public async Task<ActionResult<MeasurableActivity>> GetMeasurableActivity(Guid Id)
        {
            var measurableActivity = await _appraisalActivityService.FetchMeasurableActivity(Id);
            return measurableActivity;

        }

        // PUT: api/MeasurableActivities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("update-measurable-activity/{id}")]
        public async Task<ActionResult<MeasurableActivity>> UpdateMeasurableActivity(Guid Id, [FromBody] MeasurableActivity measurableActivity)
        {
            var updatedActivity = await _appraisalActivityService.UpdateMeasurableActivity(Id, measurableActivity);
            return Ok(updatedActivity);
        }

        // POST: api/MeasurableActivities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("aad-measurable-activity")]
        public async Task<MeasurableActivityViewModel> AddMeasurableActivity(MeasurableActivityCreateModel measurableActivity)
        {
            return await _appraisalActivityService.AddMeasurableActivity(measurableActivity);

        }

        // DELETE: api/MeasurableActivities/5
        /*[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeasurableActivity(int id)
        {
            var measurableActivity = await _context.MeasurableActivities.FindAsync(id);
            if (measurableActivity == null)
            {
                return NotFound();
            }

            _context.MeasurableActivities.Remove(measurableActivity);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/


    }
}
