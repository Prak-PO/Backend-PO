using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend_PO.Data;
using Backend_PO.Interfaces;
using Backend_PO.Models;

namespace Backend_PO.Services
{
    public class KursService : IKursService
    {
        private readonly AppDbContext _context;

        public KursService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Kurs> CreateKursAsync(Kurs kurs)
        {
            _context.Kurs.Add(kurs);
            await _context.SaveChangesAsync();
            return kurs;
        }

        public async Task<Kurs?> GetKursByIdAsync(int id)
        {
            return await _context.Kurs.FindAsync(id);
        }

        public async Task<List<Kurs>> GetAllKursAsync()
        {
            return await _context.Kurs.ToListAsync();
        }

        public async Task<bool> UpdateKursAsync(int id, Kurs updatedKurs)
        {
            var existingKurs = await _context.Kurs.FindAsync(id);

            if (existingKurs == null)
                return false;

            existingKurs.Title = updatedKurs.Title;
            existingKurs.Description = updatedKurs.Description;
            existingKurs.VideoUrl = updatedKurs.VideoUrl;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteKursAsync(int id)
        {
            var kurs = await _context.Kurs.FindAsync(id);

            if (kurs == null)
                return false;

            _context.Kurs.Remove(kurs);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}