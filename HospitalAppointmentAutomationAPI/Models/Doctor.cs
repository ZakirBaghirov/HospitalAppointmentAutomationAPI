using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentAutomationAPI.Models
{
    public enum Roles
    {
        Kardiyoloji,
        BeyinCerrahi,
        Stajyer
    }
    public class Doctor:User
    {
        
        public Roles Role { get; set; }
    }
}
