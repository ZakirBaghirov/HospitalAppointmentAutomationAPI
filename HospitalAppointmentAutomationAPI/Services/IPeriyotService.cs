using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAppointmentAutomationAPI.Models;

namespace HospitalAppointmentAutomationAPI.Services
{
    public interface IPeriyotService
    {
        Task<IEnumerable<Periyot>> GetPeriyotsAsync();
        Task<Periyot> GetPeriyotByIdAsync(string id);
        Task<bool> CreatePeriyotAsync(Periyot periyot);
        Task<bool> UpdatePeriyotAsync(Periyot periyot);
        Task<bool> DeletePeriyotAsync(string id);
    }
}
