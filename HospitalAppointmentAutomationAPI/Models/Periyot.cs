using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentAutomationAPI.Models
{
    public class Periyot
    {
        [Key] public string Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsBooked { get; set; }
        public string DoctorId { get; set; }
    }

}
