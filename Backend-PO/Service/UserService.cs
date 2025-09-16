using Backend_PO.Data;
using Backend_PO.DTOs.Requests;
using Backend_PO.DTOs.Responses;
using Backend_PO.Interfaces;
using Backend_PO.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_PO.Service
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> CreateAsync(User user)
        {
            user.CreatedAt = DateTime.UtcNow;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                var exists = await _context.Users.AnyAsync(u => u.Id == user.Id);
                return exists;
            }
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            // Ищем пользователя в базе данных по email и паролю
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email && u.Password == request.Password);

            // Если пользователь не найден, возвращаем ошибку
            if (user == null)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = "Invalid email or password"
                };
            }

            // Если пользователь найден, возвращаем успешный результат
            return new LoginResponse
            {
                Success = true,
                Message = "Login successful",
                UserName = user.Name
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}


