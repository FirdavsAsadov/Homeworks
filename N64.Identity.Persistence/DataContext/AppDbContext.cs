
using Microsoft.EntityFrameworkCore;
using N64.Identity.Application.Common.Identity.Models;
using N64.Identity.Domain.Entities;

namespace N64.Identity.Persistence.DataContext;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Token> Tokens => Set<Token>();
    public DbSet<VerificationCode> VerificationCodes => Set<VerificationCode>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MyFirstEfCoreApp;Username=postgres;Password=postgres");
    }
}
