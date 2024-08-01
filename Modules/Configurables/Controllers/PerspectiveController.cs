﻿using AppraisalTracker.Modules.AppraisalActivity.Models;
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

        // Retrieves all perspectives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfigMenuItem>>> GetPerspectives()
        {
            var perspectives = await _configMenuItemService.FetchPerspectives();
            return Ok(perspectives);
        }

        // Retrieves a single perspective
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

        // Adds a perspective
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


        // Updates a perspective
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


        // Deletes a perspective
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

