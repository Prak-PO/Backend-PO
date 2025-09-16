using Backend_PO.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend_PO.Interfaces
{
    public interface ICommentService
    {
        Task<Comment> CreateCommentAsync(Comment comment);
        Task<Comment?> GetCommentByIdAsync(int id);
        Task<List<Comment>> GetAllCommentsAsync();
        Task<bool> UpdateCommentAsync(int id, Comment updatedComment);
        Task<bool> DeleteCommentAsync(int id);
    }
}