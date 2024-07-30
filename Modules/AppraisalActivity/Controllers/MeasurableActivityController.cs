using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppraisalTracker.Modules.AppraisalActivity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppraisalTracker.Data;
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
        [HttpGet("GetMeasurableActivities")]
        public async Task<ActionResult<MeasurableActivity>> GetMeasurableActivities()
        {
            var measurableActivities = await _appraisalActivityService.FetchMeasurableActivities();
            return Ok(measurableActivities);
        }

        // GET: api/MeasurableActivities/5
        [HttpGet("GetOneMeasurableActivity")]
        public async Task<ActionResult<MeasurableActivity>> GetMeasurableActivity(int id)
        {
            var measurableActivity = await _appraisalActivityService.FetchMeasurableActivity(id);
            return measurableActivity;

        }

        // PUT: api/MeasurableActivities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("UpdateMeasurableActivities")]
        public async Task<MeasurableActivity> UpdateMeasurableActivity([FromBody] MeasurableActivity measurableActivity)
        {
            return await _appraisalActivityService.UpdateMeasurableActivity(measurableActivity);

        }

        // POST: api/MeasurableActivities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("CreateMeasurableActivity")]
        public async Task<MeasurableActivity> PostMeasurableActivity(MeasurableActivity measurableActivity)
        {
            return await _appraisalActivityService.PostMeasurableActivity(measurableActivity);

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
