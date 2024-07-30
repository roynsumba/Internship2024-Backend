using AppraisalTracker.Modules.AppraisalActivity.Models;
using AppraisalTracker.Modules.AppraisalActivity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppraisalTracker.Modules.AppraisalActivity.Controllers
{
    [Route("api/ConfigMenuItems")]
    [ApiController]
    public class ConfigMenuItemsController : ControllerBase
    {

        private readonly IConfigMenuItemService _configMenuItemService;
        public ConfigMenuItemsController(IConfigMenuItemService configMenuItemService)
        {
            _configMenuItemService = configMenuItemService;
        }

    
        [HttpGet("GetConfigMenuItems")]
        public async Task<ActionResult<ConfigMenuItem>> GetConfigMenuItems()
        {
            var configMenuItems = await _configMenuItemService.FetchConfigMenuItems();
            return Ok(configMenuItems);
        }

        [HttpPost("CreateConfigMenuItem")]
        public async Task<ConfigMenuItem> PostConfigMenuItem(ConfigMenuItem configMenuItem)
        {
            return await _configMenuItemService.PostConfigMenuItem(configMenuItem);

        }



    }
}
