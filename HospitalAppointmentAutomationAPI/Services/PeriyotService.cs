using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HospitalAppointmentAutomationAPI.Models;

namespace HospitalAppointmentAutomationAPI.Services
{
    public class PeriyotService : IPeriyotService
    {
        private readonly ApplicationDbContext _context;

        public PeriyotService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Periyot>> GetPeriyotsAsync()
        {
            return await _context.Periyots.ToListAsync();
        }

        public async Task<Periyot> GetPeriyotByIdAsync(string id)
        {
            return await _context.Periyots.FindAsync(id);
        }

        public async Task<bool> CreatePeriyotAsync(Periyot periyot)
        {
            

            _context.Periyots.Add(periyot);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePeriyotAsync(Periyot periyot)
        {
           

            _context.Entry(periyot).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePeriyotAsync(string id)
        {
            var periyot = await _context.Periyots.FindAsync(id);
            if (periyot == null)
            {
                return false;
            }

            _context.Periyots.Remove(periyot);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
