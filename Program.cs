using ClassRoomApi.DataBase;
using ClassRoomApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlite("DATA SOURCE = classroom.db");
});

builder.Services.AddIdentity<User,Roles>()
                .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("CheckAdmin",options =>
    {
        options.RequireRole("Admin");
    });

    option.AddPolicy("CheckStudent", options =>
    {
        options.RequireRole("Student");
    });

    option.AddPolicy("CheckTeacher", options =>
    {
        options.RequireRole("Teacher");
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();