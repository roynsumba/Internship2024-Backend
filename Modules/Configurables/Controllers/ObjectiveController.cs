using AppraisalTracker.Modules.AppraisalActivity.Models;
using AppraisalTracker.Modules.AppraisalActivity.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppraisalTracker.Modules.AppraisalActivity.Controllers
{
    [Route("api/ssmarta-objective")]
    [ApiController]
    public class ObjectiveController : ControllerBase
    {
        private readonly IConfigMenuItemService _configMenuItemService;

        public ObjectiveController(IConfigMenuItemService configMenuItemService)
        {
            _configMenuItemService = configMenuItemService;
        }

        [HttpPost("create-objective-item")]
        public async Task<ActionResult> CreateObjectiveItemAsync(ConfigMenuItem objectiveItem)
        {
            var result = await _configMenuItemService.AddObjectiveItem(objectiveItem);
            return Ok(result);
        }

        [HttpGet("all-objective-items")]
        public async Task<ActionResult<List<ConfigMenuItem>>> GetAllObjectiveItems()
        {
            var result = await _configMenuItemService.GetAllObjectiveItems();
            return Ok(result);
        }

        [HttpGet("objective-item/{id}")]
        public async Task<ActionResult<ConfigMenuItem>> GetObjectiveItemAsync(Guid id)
        {
            var result = await _configMenuItemService.GetAnObjectiveItem(id);
            return Ok(result);
        }

        [HttpPost("update-objective-item/{id}")]
        public async Task<ActionResult<ConfigMenuItem>> UpdateObjectiveItemAsync(Guid id, ConfigMenuItem objectiveItem)
        {
            var result = await _configMenuItemService.UpdateObjectiveItem(id, objectiveItem);
            return Ok(result);
        }

        [HttpDelete("delete-objective-item/{id}")]
        public async Task<ActionResult<ConfigMenuItem>> DeleteObjectiveItemAsync(Guid id)
        {
            var result = await _configMenuItemService.DeleteAnObjective(id);
            return Ok(result);
        }
    }
}
