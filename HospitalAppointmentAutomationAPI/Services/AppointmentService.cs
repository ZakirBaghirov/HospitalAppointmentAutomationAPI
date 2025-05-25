using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HospitalAppointmentAutomationAPI.Models;

namespace HospitalAppointmentAutomationAPI.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _context;

        public AppointmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<Appointment> GetAppointmentByIdAsync(string id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task<bool> CreateAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAppointmentAsync(Appointment appointment)
        {
            _context.Entry(appointment).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAppointmentAsync(string id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return false;
            }
            _context.Appointments.Remove(appointment);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
