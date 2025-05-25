using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HospitalAppointmentAutomationAPI.Models;

namespace HospitalAppointmentAutomationAPI.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;

        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Admin>> GetAdminsAsync()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task<Admin> GetAdminByIdAsync(Guid id)
        {
            return await _context.Admins.FindAsync(id);
        }

        public async Task<Admin> AddAdminAsync(Admin admin)
        {
            var entry = await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<bool> UpdateAdminAsync(Admin admin)
        {
            _context.Entry(admin).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAdminAsync(Guid id)
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
            {
                return false;
            }
            _context.Admins.Remove(admin);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AdminAuthenticationAsync(string username, string password)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Username == username && a.Password == password);
            return admin != null;
        }

        // For doctors
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

        // For appointments
        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync()
        {
            return await _context.Appointments.Include(a => a.UserId).Include(a => a.PeriyotId).ToListAsync();
        }

        public async Task<Appointment> GetAppointmentByIdAsync(string id)
        {
            return await _context.Appointments.Include(a => a.UserId).Include(a => a.PeriyotId).FirstOrDefaultAsync(a => a.Id == id);
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
        //periyotlarla 
        public async Task<IEnumerable<Periyot>> GetPeriyotsAsync()
        {
            return await _context.Periyots.ToListAsync();
        }

        public async Task<Periyot> GetPeriyotByIdAsync(string id)
        {
            return await _context.Periyots.FindAsync(id);
        }

        public async Task<bool> CreatePeriyotAsync(Periyot periyot)
        {
            _context.Periyots.Add(periyot);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePeriyotAsync(Periyot periyot)
        {
            _context.Entry(periyot).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePeriyotAsync(string id)
        {
            var periyot = await _context.Periyots.FindAsync(id);
            if (periyot == null)
            {
                return false;
            }

            _context.Periyots.Remove(periyot);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}