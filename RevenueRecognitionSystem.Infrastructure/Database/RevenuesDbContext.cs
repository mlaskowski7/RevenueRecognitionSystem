using Microsoft.EntityFrameworkCore;
using RevenueRecognitionSystem.Domain.Models;

namespace RevenueRecognitionSystem.Infrastructure.Database;

public class RevenuesDbContext(DbContextOptions<RevenuesDbContext> opt) : DbContext(opt)
{
    public DbSet<IndividualClient> IndividualClients { get; set; }
    
    public DbSet<CompanyClient> CompanyClients { get; set; }
    
    public DbSet<Client> Clients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RevenuesDbContext).Assembly);
    }
    
}