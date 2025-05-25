using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentAutomationAPI.Models
{
    public class AuditLog
    {   
        [Key] public int? Id { get; set; }
        public string TableName { get; set; }
        public string EntityId { get; set; }
        public string Action { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
