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
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IAuditLog _auditLog;

       
        public AppointmentController(IAppointmentService appointmentService, IAuditLog auditLog)
        {
            _appointmentService = appointmentService;
            _auditLog = auditLog;
        }

        // GET: api/Appointment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            return Ok(await _appointmentService.GetAppointmentsAsync());
        }

        // GET: api/Appointment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(string id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(string id, Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return BadRequest();
            }

            

            // Log kaydı oluşturma
            var log = new AuditLog
            {
                Id = null,
                UserId = appointment.Id.ToString(),
                TableName = "Appointment",
                EntityId = appointment.Id.ToString(),
                Action = "Update",
                Date = DateTime.Now
            };
            _auditLog.LogAudit(log);

            await _appointmentService.UpdateAppointmentAsync(appointment);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            

            // Log kaydı oluşturma
            var log = new AuditLog
            {
                Id = null,
                UserId = appointment.Id.ToString(),
                TableName = "Appointment",
                EntityId = appointment.Id.ToString(),
                Action = "Create",
                Date = DateTime.Now
            };
            _auditLog.LogAudit(log);

            await _appointmentService.CreateAppointmentAsync(appointment);

            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
        }


        // DELETE: api/Appointment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(string id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            // Log kaydı oluşturma
            var log = new AuditLog
            {
                Id = null,
                UserId = appointment.Id.ToString(),
                TableName = "Appointment",
                EntityId = appointment.Id.ToString(),
                Action = "Delete",
                Date = DateTime.Now
            };
            _auditLog.LogAudit(log);

            await _appointmentService.DeleteAppointmentAsync(id);

            return NoContent();
        }
    }
}