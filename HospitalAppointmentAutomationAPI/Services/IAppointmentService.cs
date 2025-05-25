using HospitalAppointmentAutomationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppointmentAutomationAPI.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAppointmentsAsync();
        Task<Appointment> GetAppointmentByIdAsync(string id);
        Task<bool> CreateAppointmentAsync(Appointment appointment);
        Task<bool> UpdateAppointmentAsync(Appointment appointment);
        Task<bool> DeleteAppointmentAsync(string id);
    }
}
