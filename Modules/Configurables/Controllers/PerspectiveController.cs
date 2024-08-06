using AppraisalTracker.Modules.AppraisalActivity.Models;
using AppraisalTracker.Modules.AppraisalActivity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppraisalTracker.Modules.AppraisalActivity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerspectiveController : ControllerBase
    {
        private readonly IConfigMenuItemService _configMenuItemService;

        public PerspectiveController(IConfigMenuItemService configMenuItemService)
        {
            _configMenuItemService = configMenuItemService;
        }

        // Retrieves all perspectives
        [HttpGet("get-all-perspectives/{userId}")]
        public async Task<ActionResult<IEnumerable<ConfigMenuItem>>> GetPerspectives([FromRoute] Guid userId)
        {
            var perspectives = await _configMenuItemService.FetchPerspectives(userId);
            return Ok(perspectives);
        }

        // Retrieves a single perspective
        [HttpGet("get-a-single-perspective/{id}")]
        public async Task<ActionResult<ConfigMenuItem>> GetPerspective(Guid id)
        {
            try
            {
                var perspective = await _configMenuItemService.FetchPerspective(id);
                return Ok(perspective);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // Adds a perspective
        [HttpPost("add-a-perspective")]
        public async Task<ActionResult<ConfigMenuItem>> AddPerspective([FromBody] ConfigMenuItem perspective)
        {
            try
            {
                var newPerspective = await _configMenuItemService.AddConfigMenuItem(perspective);
                return CreatedAtAction(nameof(GetPerspective), new { id = newPerspective.ItemId }, newPerspective);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // Updates a perspective
        [HttpPut("update-a-perspective/{id}")]
        public async Task<ActionResult<ConfigMenuItem>> UpdatePerspective(Guid id, ConfigMenuItem perspective)
        {
            try
            {
                var updatedPerspective = await _configMenuItemService.UpdatePerspective( id,perspective);
                return Ok(updatedPerspective);
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


        // Deletes a perspective
        [HttpDelete("delete-a-perspective/{id}")]
        public async Task<ActionResult> DeletePerspective(Guid id)
        {
            try
            {
                var deleted = await _configMenuItemService.DeletePerspective(id);
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

