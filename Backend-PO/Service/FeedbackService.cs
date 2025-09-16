using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend_PO.Data;
using Backend_PO.DTOs.Requests;
using Backend_PO.Interfaces;
using Backend_PO.Models;

namespace Backend_PO.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly AppDbContext _context;

        public FeedbackService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Feedback> CreateFeedbackAsync(CreateFeedbackRequest request)
        {
            var feedback = new Feedback
            {
                Rating = request.Rating,
                Notes = request.Notes,
                UserId = request.UserId,
                KursId = request.KursId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return feedback;
        }

        public async Task<Feedback?> GetFeedbackByIdAsync(int id)
        {
            return await _context.Feedbacks.FindAsync(id);
        }

        public async Task<List<Feedback>> GetAllFeedbackAsync()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        public async Task<bool> UpdateFeedbackAsync(int id, UpdateFeedbackRequest request)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);

            if (feedback == null)
                return false;

            if (request.Rating.HasValue)
                feedback.Rating = request.Rating.Value;

            if (request.Notes != null)
                feedback.Notes = request.Notes;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteFeedbackAsync(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);

            if (feedback == null)
                return false;

            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}