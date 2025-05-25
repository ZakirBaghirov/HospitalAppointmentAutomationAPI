using System;
using System.ComponentModel.DataAnnotations;
using HospitalAppointmentAutomationAPI.Models;
using HospitalAppointmentAutomationAPI.Services;
namespace HospitalAppointmentAutomationAPI.Services
{
    public interface IAuditLog
    {
        void LogAudit(AuditLog auditLog);
    }
}
