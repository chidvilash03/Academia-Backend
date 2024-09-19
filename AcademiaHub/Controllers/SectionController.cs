using DatabaseAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace AcademiaHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectionController : ControllerBase
    {
        private readonly ISectionServices _sectionService;

        public SectionController(ISectionServices sectionService)
        {
            _sectionService = sectionService;
        }

        [HttpGet]
        [Route("GetAllSectionDetails")]
        public async Task<IActionResult> GetAllSectionDetails()
        {
            var sections = await _sectionService.GetAllSectionsAsync();
            return Ok(sections);
        }

        [HttpGet("GetSectionDetailsById/{id}")]
        public async Task<IActionResult> GetSectionDetailsById(int id)
        {
            var section = await _sectionService.GetSectionByIdAsync(id);
            if (section == null)
            {
                return NotFound();
            }
            return Ok(section);
        }

        [HttpPost]
        [Route("AddSectionDetails")]
        public async Task<IActionResult> AddSection([FromBody] Section section)
        {
            await _sectionService.AddSectionAsync(section);
            return CreatedAtAction(nameof(GetSectionDetailsById), new { id = section.SectionId }, section);
        }

        [HttpPut("UpdateSectionDetailsById/{id}")]
        public async Task<IActionResult> UpdateSectionDetailsById(int id, [FromBody] Section section)
        {
            if (id != section.SectionId)
            {
                return BadRequest();
            }
            await _sectionService.UpdateSectionAsync(section);
            return NoContent();
        }

        [HttpDelete("DeleteSectionDetailsById/{id}")]

        public async Task<IActionResult> DeleteSectionById(int id)
        {
            await _sectionService.DeleteSectionByIdAsync(id);
            return NoContent();
        }
    }
}
