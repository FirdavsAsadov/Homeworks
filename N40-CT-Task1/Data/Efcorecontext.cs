using Microsoft.EntityFrameworkCore;

namespace N40_CT_Task1.Data
{
    public class Efcorecontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("Server=localhost;Port=5433;UserName=postgres;Database=postgres;Password=fedya_2006");
        public DbSet<Student> Students { get; set; }
    }

    
}