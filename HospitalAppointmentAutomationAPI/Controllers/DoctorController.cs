using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HospitalAppointmentAutomationAPI.Services;
using HospitalAppointmentAutomationAPI.Models;

namespace HospitalAppointmentAutomationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IAuditLog _auditLog;

        public DoctorController(IDoctorService doctorService, IAuditLog auditLog)
        {
            _doctorService = doctorService;
            _auditLog = auditLog;
        }

        // GET: api/Doctor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctor()
        {
            var doctors = await _doctorService.GetDoctorsAsync();
            return Ok(doctors);
        }

        // GET: api/Doctor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(Guid id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        // POST: api/Doctor
        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
            await _doctorService.CreateDoctorAsync(doctor);

            // Log kaydı oluşturma
            var log = new AuditLog
            { 
                Id = null,
                UserId=doctor.Id.ToString(),
                TableName = "Doctor",
                EntityId = doctor.Id.ToString(),
                Action = "Create",
                Date = DateTime.Now
            };
            _auditLog.LogAudit(log);

            return CreatedAtAction(nameof(GetDoctor), new { id = doctor.Id }, doctor);
        }

        // PUT: api/Doctor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(Guid id, Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return BadRequest();
            }

            await _doctorService.UpdateDoctorAsync(doctor);

            // Log kaydı oluşturma
            var log = new AuditLog
            {

                Id = null,
                UserId = doctor.Id.ToString(),
                TableName = "Doctor",
                EntityId = id.ToString(),
                Action = "Update",
                Date = DateTime.Now
            };
            _auditLog.LogAudit(log);

            return NoContent();
        }

        // DELETE: api/Doctor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(Guid id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            await _doctorService.DeleteDoctorAsync(id);

            // Log kaydı oluşturma
            var log = new AuditLog
            {
                Id = null,
                UserId = doctor.Id.ToString(),
                TableName = "Doctor",
                EntityId = id.ToString(),
                Action = "Delete",
                Date = DateTime.Now
            };
            _auditLog.LogAudit(log);

            return NoContent();
        }
    }
}
