using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalAppointmentAutomationAPI.Models;

namespace HospitalAppointmentAutomationAPI.Services
{
    public interface IAdminService
    {
        // Admin related operations
        Task<IEnumerable<Admin>> GetAdminsAsync();
        Task<Admin> GetAdminByIdAsync(Guid id);
        Task<Admin> AddAdminAsync(Admin admin);
        Task<bool> UpdateAdminAsync(Admin admin);
        Task<bool> DeleteAdminAsync(Guid id);
        Task<bool> AdminAuthenticationAsync(string username, string password);

        // For doctors
        Task<IEnumerable<Doctor>> GetDoctorsAsync();
        Task<Doctor> GetDoctorByIdAsync(Guid id);
        Task<bool> CreateDoctorAsync(Doctor doctor);
        Task<bool> UpdateDoctorAsync(Doctor doctor);
        Task<bool> DeleteDoctorAsync(Guid id);

        // For appointments
        Task<IEnumerable<Appointment>> GetAppointmentsAsync();
        Task<Appointment> GetAppointmentByIdAsync(string id);
        Task<bool> CreateAppointmentAsync(Appointment appointment);
        Task<bool> UpdateAppointmentAsync(Appointment appointment);
        Task<bool> DeleteAppointmentAsync(string id);
        
        // For periyots
        Task<IEnumerable<Periyot>> GetPeriyotsAsync();
        Task<Periyot> GetPeriyotByIdAsync(string id);
        Task<bool> CreatePeriyotAsync(Periyot periyot );
        Task<bool> UpdatePeriyotAsync(Periyot periyot);
        Task<bool> DeletePeriyotAsync(string id);
    }
}
