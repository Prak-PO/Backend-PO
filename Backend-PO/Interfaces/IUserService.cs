using Backend_PO.DTOs.Requests;
using Backend_PO.DTOs.Responses;
using Backend_PO.Models;

namespace Backend_PO.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User> CreateAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task<User?> LoginAsync(LoginRequest request);
        Task<bool> DeleteAsync(int id);
    }
}


