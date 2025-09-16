using Microsoft.EntityFrameworkCore;
using Backend_PO.Interfaces; // ������������ ���� ��� �����������
using Backend_PO.Services;   // ������������ ���� ��� ���������� ��������
using Backend_PO.Data;
using Backend_PO.Service;       // ������������ ���� ��� ��������� ���� ������

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

// Dependency Injection: ����������� ����������� � �� ����������
builder.Services.AddScoped<IUserService, UserService>();       // ������ ��� ������������ �������
builder.Services.AddScoped<ICommentService, CommentService>(); // ��������� ����� ������
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