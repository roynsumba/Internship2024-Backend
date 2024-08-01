using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppraisalTracker.Modules.AppraisalActivity.Models;
using AppraisalTracker.Modules.AppraisalActivity.Services;

namespace AppraisalTracker.Modules.AppraisalActivity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitiativeController : ControllerBase
    {
        private readonly IConfigMenuItemService _configMenuItemService;

        public InitiativeController(IConfigMenuItemService configMenuItemService)
        {
            _configMenuItemService = configMenuItemService;
        }

        // Retrieves all initiatives.
        [HttpGet("get-all-initiatives")]
        public async Task<ActionResult<IEnumerable<ConfigMenuItem>>> GetInitiatives()
        {
            var initiatives = await _configMenuItemService.FetchInitiatives();
            return Ok(initiatives);
        }

        // Retrieves a single initiative
        [HttpGet("get-a-single-initiative/{id}")]
        public async Task<ActionResult<ConfigMenuItem>> GetInitiative(Guid id)
        {
            try
            {
                var initiative = await _configMenuItemService.FetchInitiative(id);
                return Ok(initiative);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // Adds an initiative
        [HttpPost("add-an-initiative")]
        public async Task<ActionResult<ConfigMenuItem>> AddInitiative([FromBody] ConfigMenuItem initiative)
        {
            try
            {
                var newInitiative = await _configMenuItemService.AddConfigMenuItem(initiative);
                return CreatedAtAction(nameof(GetInitiative), new { id = newInitiative.ItemId }, newInitiative);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // Updates an initiative
        [HttpPut("update-an-initiative/{id}")]
        public async Task<ActionResult<ConfigMenuItem>> UpdateInitiative(Guid id, ConfigMenuItem initiative)
        {
            try
            {
                var updatedInitiative = await _configMenuItemService.UpdateInitiative(id, initiative);
                return Ok(updatedInitiative);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // Deletes an initiative
        [HttpDelete("delete-an-initiative{id}")]
        public async Task<ActionResult> DeleteInitiative(Guid id)
        {
            try
            {
                var deleted = await _configMenuItemService.DeleteInitiative(id);
                if (deleted)
                {
                    return NoContent();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
