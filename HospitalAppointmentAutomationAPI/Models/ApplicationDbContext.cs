using Microsoft.EntityFrameworkCore;
using HospitalAppointmentAutomationAPI.Models;


namespace HospitalAppointmentAutomationAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Periyot> Periyots { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

    }
}

