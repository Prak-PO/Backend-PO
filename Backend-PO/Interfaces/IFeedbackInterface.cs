using System.Collections.Generic;
using System.Threading.Tasks;
using Backend_PO.DTOs.Requests;
using Backend_PO.Models;

namespace Backend_PO.Interfaces
{
    public interface IFeedbackService
    {
        Task<Feedback> CreateFeedbackAsync(CreateFeedbackRequest request);
        Task<Feedback?> GetFeedbackByIdAsync(int id);
        Task<List<Feedback>> GetAllFeedbackAsync();
        Task<bool> UpdateFeedbackAsync(int id, UpdateFeedbackRequest request);
        Task<bool> DeleteFeedbackAsync(int id);
    }
}