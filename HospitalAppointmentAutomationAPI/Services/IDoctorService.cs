using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAppointmentAutomationAPI.Models;

namespace HospitalAppointmentAutomationAPI.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetDoctorsAsync();
        Task<Doctor> GetDoctorByIdAsync(Guid id);
        Task<bool> CreateDoctorAsync(Doctor doctor);
        Task<bool> UpdateDoctorAsync(Doctor doctor);
        Task<bool> DeleteDoctorAsync(Guid id);
    }
}
