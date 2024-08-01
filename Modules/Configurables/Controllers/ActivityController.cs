//Activity controller 
using AppraisalTracker.Modules.AppraisalActivity.Models;
using AppraisalTracker.Modules.AppraisalActivity.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppraisalTracker.Modules.AppraisalActivity.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IConfigMenuItemService _configMenuItemService;
        public ActivityController(IConfigMenuItemService configMenuItemService)
        {
            _configMenuItemService = configMenuItemService;
        }
        // Creating a new activity Item
        [HttpPost("create-activity-item")]
        public async Task<ActionResult> CreateActivityItemAsync(ConfigMenuItem activityItem)
        {
            await _configMenuItemService.AddActivityItem(activityItem);
            return Ok(activityItem);
        }

        // Returning all measurable activities
        [HttpGet("all-activity-items")]
        public async Task<ActionResult<List<ConfigMenuItem>>> GetAllActivityItems()
        {
            var activityItems = await _configMenuItemService.GetAllActivityItems();
            return Ok(activityItems);
        }

        // Querying a single activity Item
        [HttpGet("activity-item/{id}")]
        public async Task<ActionResult<ConfigMenuItem>> GetActivityItemAsync(Guid id)
        {
            var activityItem = await _configMenuItemService.GetAnActivityItem(id);
            if (activityItem == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(activityItem);
            }
        }

        // Updating an Item
        [HttpPost("update-activity-item/{id}")]
        public async Task<ActionResult<ConfigMenuItem>> UpdateActivityItemAsync(Guid id, ConfigMenuItem activityItem)
        {
            try
            {
                var updatedActivityItem = await _configMenuItemService.UpdateAnActivityItem(id, activityItem);
                return Ok(updatedActivityItem);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Activity record for update not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the activity item: {ex.Message}");
            }
        }

        // Deleting an activity item record
        [HttpDelete("delete-activity-item/{id}")]
        public async Task<ActionResult<ConfigMenuItem>> DeleteActivityItemAsync(Guid id)
        {
            try
            {
                var deletedActivityItem = await _configMenuItemService.DeleteAnActivity(id);
                return Ok(deletedActivityItem);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Activity record for deletion not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the activity item: {ex.Message}");
            }
        }
    }
}
