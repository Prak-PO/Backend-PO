using Backend_PO.DTOs.Requests;
using Backend_PO.Interfaces;
using Backend_PO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_PO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _userService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var created = await _userService.CreateAsync(user);
            return CreatedAtAction("GetUser", new { id = created.Id }, created);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // ѕровер€ем, что запрос содержит данные
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new { message = "Invalid request data" });
            }

            // ѕровер€ем учетные данные через сервис
            var loginResult = await _userService.LoginAsync(request);

            // ≈сли пользователь не найден или пароль неверный, возвращаем ошибку
            if (!loginResult.Success)
            {
                return Unauthorized(new { message = loginResult.Message });
            }

            // ≈сли все хорошо, возвращаем успешный ответ
            return Ok(new { message = "Login successful", userName = loginResult.UserName });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var ok = await _userService.UpdateAsync(user);
            return ok ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var ok = await _userService.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }

    }
}

