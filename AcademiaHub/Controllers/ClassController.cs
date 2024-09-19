using DatabaseAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using System.Security.Claims;

namespace AcademiaHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly IClassServices _classServices;

        public ClassController(IClassServices classServices)
        {
            _classServices = classServices;
        }

        [HttpGet]
        [Route("GetAllClassDetails")]
        public async Task<IActionResult> GetAllHostelDetails()
        {
            var classes = await _classServices.GetAllClassDetailsAsync();
            return Ok(classes);
        }

        [HttpGet("GetClassDetailsById/{id}")]
        public async Task<IActionResult> GetClassDetailsById(int id)
        {
            var classDetails = await _classServices.GetClassByIdAsync(id);
            if (classDetails == null)
            {
                return NotFound();
            }
            return Ok(classDetails);
        }

        [HttpPost]
        [Route("AddClassDetails")]
        public async Task<IActionResult> AddClass([FromBody] Class classDetails)
        {
            await _classServices.AddClassAsync(classDetails);
            return CreatedAtAction(nameof(GetClassDetailsById), new { id = classDetails.ClassId }, classDetails);
        }

        [HttpPut("UpdateClassDetailsById/{id}")]
        public async Task<IActionResult> UpdateClassDetailsById(int id, [FromBody] Class classDetails)
        {
            if (id != classDetails.ClassId)
            {
                return BadRequest();
            }
            await _classServices.UpdateClassAsync(classDetails);
            return NoContent();
        }

        [HttpDelete("DeleteClassDetailsById/{id}")]

        public async Task<IActionResult> DeleteClassDetailsById(int id)
        {
            await _classServices.DeleteClassByIdAsync(id);
            return NoContent();
        }
    }
}
