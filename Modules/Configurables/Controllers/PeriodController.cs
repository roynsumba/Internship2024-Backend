using AppraisalTracker.Modules.AppraisalActivity.Models;
using AppraisalTracker.Modules.AppraisalActivity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppraisalTracker.Modules.Configurables.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodController : ControllerBase
    {

        private readonly IConfigMenuItemService _configMenuItemService;

        public PeriodController(IConfigMenuItemService configMenuItemService)
        {
            _configMenuItemService = configMenuItemService;
        }

        [HttpPost("create-period-item")]
        public async Task<ActionResult> CreatePeriodItemAsync(ConfigMenuItem periodItem)
        {
            var result = await _configMenuItemService.AddPeriodItem(periodItem);
            return Ok(result);
        }

        [HttpGet("all-period-items")]
        public async Task<ActionResult<List<ConfigMenuItem>>> GetAllPeriodItems()
        {
            var result = await _configMenuItemService.GetPeriodItems();
            return Ok(result);
        }

        [HttpGet("period-item/{id}")]
        public async Task<ActionResult<ConfigMenuItem>> GetPeriodItemAsync(Guid id)
        {
            var result = await _configMenuItemService.GetAPeriodItem(id);
            return Ok(result);
        }

        [HttpPost("update-period-item/{id}")]
        public async Task<ActionResult<ConfigMenuItem>> UpdatePeriodItemAsync(Guid id, ConfigMenuItem periodItem)
        {
            var result = await _configMenuItemService.UpdateAPeriodItem(id, periodItem);
            return Ok(result);
        }

        [HttpDelete("delete-period-item/{id}")]
        public async Task<ActionResult<ConfigMenuItem>> DeletePeriodItemAsync(Guid id)
        {
            var result = await _configMenuItemService.DeleteAPeriod(id);
            return Ok(result);
        }

    }
}
