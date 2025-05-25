using HospitalAppointmentAutomationAPI.Models;
using HospitalAppointmentAutomationAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointmentAutomationAPI.Services
{
    public class AuditLogService : IAuditLog
    {
        private readonly ApplicationDbContext dbContext;
        public AuditLogService(ApplicationDbContext dbContextt)
        {
            dbContext = dbContextt;
        }
        public void LogAudit(AuditLog auditLog)
        {
                dbContext.AuditLogs.Add(auditLog);
                dbContext.SaveChanges();
        }
    }
}
