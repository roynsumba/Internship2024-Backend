using AppraisalTracker.Modules.AppraisalActivity.Models;
using AppraisalTracker.Modules.AppraisalActivity.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppraisalTracker.Modules.AppraisalActivity.Controllers
{
    [Route("api/configurables")]
    [ApiController]
    public class ConfigMenuItemsController : ControllerBase
    {

        private readonly IConfigMenuItemService _configMenuItemService;
        public ConfigMenuItemsController(IConfigMenuItemService configMenuItemService)
        {
            _configMenuItemService = configMenuItemService;
        }

        [HttpGet("get-all-config-items")]
        public async Task<ActionResult<ConfigMenuItem>> GetConfigMenuItems(Guid userId)

        {
            var configMenuItems = await _configMenuItemService.FetchConfigMenuItems(userId);
            return Ok(configMenuItems);
        }

        [HttpPost("add-config-item")]
        public async Task<ConfigMenuItem> PostConfigMenuItem(ConfigMenuItem configMenuItem)
        {
            return await _configMenuItemService.AddConfigMenuItem(configMenuItem);

        }



    }
}
