using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentAutomationAPI.Models
{
    public class Appointment
    {
        [Key]
        public string Id { get; set; }  
        public string PeriyotId { get; set; }
        public string UserId { get; set; }

    }
}
