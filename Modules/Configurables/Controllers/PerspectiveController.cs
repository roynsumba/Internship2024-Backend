using AppraisalTracker.Modules.AppraisalActivity.Models;
using AppraisalTracker.Modules.AppraisalActivity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppraisalTracker.Modules.AppraisalActivity.Controllers
{
    [Route("perspective")]
    [ApiController]
    public class PerspectiveController : ControllerBase
    {
        private readonly IConfigMenuItemService _configMenuItemService;

        public PerspectiveController(IConfigMenuItemService configMenuItemService)
        {
            _configMenuItemService = configMenuItemService;
        }

        // GET: api/Perspectives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfigMenuItem>>> GetPerspectives()
        {
            var perspectives = await _configMenuItemService.FetchPerspectives();
            return Ok(perspectives);
        }

        // GET: api/Perspectives/{id}
        [HttpGet("{id}")]
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

        // POST: api/Perspectives
        [HttpPost]
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



        [HttpPost("{id}")]
        public async Task<ActionResult<ConfigMenuItem>> UpdatePerspective(Guid id, [FromBody] ConfigMenuItem perspective)
        {
            if (id != perspective.ItemId)
            {
                return BadRequest("ID mismatch.");
            }

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


        // DELETE: api/Perspectives/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerspective(Guid id)
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

