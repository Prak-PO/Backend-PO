using Microsoft.EntityFrameworkCore;
using Backend_PO.Interfaces; // Пространство имен для интерфейсов
using Backend_PO.Services;   // Пространство имен для реализаций сервисов
using Backend_PO.Data;
using Backend_PO.Service;       // Пространство имен для контекста базы данных

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Dependency Injection: регистрация интерфейсов и их реализаций
builder.Services.AddScoped<IUserService, UserService>();       // Пример уже добавленного сервиса
builder.Services.AddScoped<ICommentService, CommentService>(); // Добавляем новый сервис
builder.Services.AddScoped<IKursService, KursService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();