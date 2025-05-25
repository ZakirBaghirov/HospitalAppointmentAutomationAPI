using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAppointmentAutomationAPI.Models;
using HospitalAppointmentAutomationAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointmentAutomationAPI.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDbContext _context;

        public DoctorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(Guid id)
        {
            return await _context.Doctors.FindAsync(id);
        }

        public async Task<bool> CreateDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateDoctorAsync(Doctor doctor)
        {
            _context.Entry(doctor).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteDoctorAsync(Guid id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return false;
            }
            _context.Doctors.Remove(doctor);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
