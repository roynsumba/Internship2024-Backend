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

        [HttpPost("create-activity-item")]
        public async Task<ActionResult> CreateActivityItemAsync(ConfigMenuItem activityItem)
        {
            var result = await _configMenuItemService.AddActivityItem(activityItem);
            return Ok(result);
        }

        [HttpGet("all-activity-items")]
        public async Task<ActionResult<List<ConfigMenuItem>>> GetAllActivityItems(Guid userId)
        {
            var result = await _configMenuItemService.GetAllActivityItems(userId);
            return Ok(result);
        }

        [HttpGet("activity-item/{id}")]
        public async Task<ActionResult<ConfigMenuItem>> GetActivityItemAsync(Guid id)
        {
            var result = await _configMenuItemService.GetAnActivityItem(id);
            return Ok(result);
        }

        [HttpPost("update-activity-item/{id}")]
        public async Task<ActionResult<ConfigMenuItem>> UpdateActivityItemAsync(Guid id, ConfigMenuItem activityItem)
        {
            var result = await _configMenuItemService.UpdateAnActivityItem(id, activityItem);
            return Ok(result);
        }

        [HttpDelete("delete-activity-item/{id}")]
        public async Task<ActionResult<ConfigMenuItem>> DeleteActivityItemAsync(Guid id)
        {
            var result = await _configMenuItemService.DeleteAnActivity(id);
            return Ok(result);
        }
    }
}
