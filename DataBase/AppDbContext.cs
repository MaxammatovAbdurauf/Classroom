using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ClassRoomApi.Entities;
using Microsoft.AspNetCore.Identity;

namespace ClassRoomApi.DataBase;

public class AppDbContext : IdentityDbContext<User,Roles, string>
{
    public AppDbContext(DbContextOptions options) : base (options) { }
    public DbSet<Room> Rooms { get; set; }
   
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Roles>().HasData(
            new IdentityRole { Id = "1", Name = "Admin"},
            new IdentityRole { Id = "2", Name = "Teacher"},
            new IdentityRole { Id = "3", Name = "Student"});
        builder.Entity<IdentityUserLogin<string>>().HasNoKey();
    }
}