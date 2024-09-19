using DatabaseAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using ServiceLayer.Interfaces;

namespace AcademiaHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HostelController : ControllerBase
    {
        private readonly IHostelServices _hostelService;

        public HostelController(IHostelServices hostelService)
        {
            _hostelService = hostelService;
        }

        [HttpGet]
        [Route("GetAllHostelDetails")]
        public async Task<IActionResult> GetAllHostelDetails()
        {
            var sections = await _hostelService.GetAllHostelDetailsAsync();
            return Ok(sections);
        }

        [HttpGet("GetHostelDetailsById/{id}")]
        public async Task<IActionResult> GetHostelDetailsById(int id)
        {
            var section = await _hostelService.GetHostelByIdAsync(id);
            if (section == null)
            {
                return NotFound();
            }
            return Ok(section);
        }

        [HttpPost]
        [Route("AddHostelDetails")]
        public async Task<IActionResult> AddHostel([FromBody] Hostel hostel)
        {
            await _hostelService.AddHostelAsync(hostel);
            return CreatedAtAction(nameof(GetHostelDetailsById), new { id = hostel.HostelId }, hostel);
        }

        [HttpPut("UpdateHostelDetailsById/{id}")]
        public async Task<IActionResult> UpdateHostelDetailsById(int id, [FromBody] Hostel hostel)
        {
            if (id != hostel.HostelId)
            {
                return BadRequest();
            }
            await _hostelService.UpdateHostelAsync(hostel);
            return NoContent();
        }

        [HttpDelete("DeleteHostelDetailsById/{id}")]

        public async Task<IActionResult> DeleteHostelById(int id)
        {
            await _hostelService.DeleteHostelByIdAsync(id);
            return NoContent();
        }
    }
}
