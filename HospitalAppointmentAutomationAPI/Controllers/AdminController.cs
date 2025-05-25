using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HospitalAppointmentAutomationAPI.Models;
using HospitalAppointmentAutomationAPI.Services;

namespace HospitalAppointmentAutomationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        // GET: api/Admin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
            return Ok(await _adminService.GetAdminsAsync());
        }

        // GET: api/Admin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdmin(Guid id)
        {
            var admin = await _adminService.GetAdminByIdAsync(id);

            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }

        // PUT: api/Admin/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(Guid id, Admin admin)
        {
            if (id != admin.Id)
            {
                return BadRequest();
            }

            var updatedAdmin = await _adminService.UpdateAdminAsync(admin);

            if (!updatedAdmin)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Admin
        [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmin(Admin admin)
        {
            var createdAdmin = await _adminService.AddAdminAsync(admin);

            if (createdAdmin == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetAdmin), new { id = createdAdmin.Id }, createdAdmin);
        }


        // DELETE: api/Admin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(Guid id)
        {
            var deleted = await _adminService.DeleteAdminAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

