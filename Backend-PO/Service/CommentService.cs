using Backend_PO.Data;
using Backend_PO.Interfaces;
using Backend_PO.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend_PO.Services
{
    public class CommentService : ICommentService
    {
        private readonly AppDbContext _context;

        public CommentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateCommentAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> GetCommentByIdAsync(int id)
        {
            return await _context.Comments
                .Include(c => c.User)
                .Include(c => c.Kurs)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await _context.Comments
                .Include(c => c.User)
                .Include(c => c.Kurs)
                .ToListAsync();
        }

        public async Task<bool> UpdateCommentAsync(int id, Comment updatedComment)
        {
            var existingComment = await _context.Comments.FindAsync(id);

            if (existingComment == null)
                return false;

            existingComment.Content = updatedComment.Content;
            existingComment.UserId = updatedComment.UserId;
            existingComment.KursId = updatedComment.KursId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCommentAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
                return false;

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}