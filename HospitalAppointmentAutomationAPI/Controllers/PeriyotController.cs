using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HospitalAppointmentAutomationAPI.Models;
using HospitalAppointmentAutomationAPI.Services;

namespace HospitalAppointmentAutomationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriyotController : ControllerBase
    {
        private readonly IPeriyotService _periyotService;
        private readonly IAuditLog _auditLog;

        public  PeriyotController(IPeriyotService periyotService, IAuditLog auditLog)
        {
            _periyotService = periyotService;
            _auditLog = auditLog;
        }

        // GET: api/Periyot
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Periyot>>> GetPeriyot() // Değiştirilen metot adı: GetPeriyot
        {
            var periyots = await _periyotService.GetPeriyotsAsync();
            return Ok(periyots);// Değiştirilen metot adı: GetPeriyots
        }

        // GET: api/Periyot/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Periyot>> GetPeriyot(string id)
        {
            var periyot = await _periyotService.GetPeriyotByIdAsync(id);

            if (periyot == null)
            {
                return NotFound();
            }

            return Ok(periyot);
        }

        // PUT: api/Periyot/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeriyot(string id, Periyot periyot)
        {
            if (id != periyot.Id)
            {
                return BadRequest();
            }

           

            // Log kaydı oluşturma
            var log = new AuditLog
            {
                Id = null,
                UserId = periyot.Id.ToString(),
                TableName = "Periyot",
                EntityId = periyot.Id.ToString(),
                Action = "Update",
                Date = DateTime.Now
            };
            _auditLog.LogAudit(log);

            var isUpdated = await _periyotService.UpdatePeriyotAsync(periyot);

            if (!isUpdated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Periyot
        [HttpPost]
        public async Task<ActionResult<Periyot>> PostPeriyot(Periyot periyot)
        {
           

            // Log kaydı oluşturma
            var log = new AuditLog
            {
                Id = null,
                UserId = periyot.Id.ToString(),
                TableName = "Periyot",
                EntityId = periyot.Id.ToString(),
                Action = "Create",
                Date = DateTime.Now
            };
            _auditLog.LogAudit(log);

            var isCreated = await _periyotService.CreatePeriyotAsync(periyot);

            if (!isCreated)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetPeriyot), new { id = periyot.Id }, periyot);
        }

        // DELETE: api/Periyot/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeriyot(string id)
        {
            var periyot = await _periyotService.GetPeriyotByIdAsync(id);

            if (periyot == null)
            {
                return NotFound();
            }

            // Log kaydı oluşturma
            var log = new AuditLog
            {
                Id = null,
                UserId = periyot.Id.ToString(),
                TableName = "Periyot",
                EntityId = periyot.Id.ToString(),
                Action = "Delete",
                Date = DateTime.Now
            };
            _auditLog.LogAudit(log);

            var isDeleted = await _periyotService.DeletePeriyotAsync(id);

            
        if (!isDeleted)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}