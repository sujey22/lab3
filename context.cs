using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<asignaturas> asignaturas { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-NFDMETJ;Database=lab3;Trusted_Connection=SSPI;MultipleActiveResultSets=true;TrustServerCertificate=true;");
    }
}

