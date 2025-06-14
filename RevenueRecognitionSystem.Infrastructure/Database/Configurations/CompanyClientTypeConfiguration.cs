using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevenueRecognitionSystem.Domain.Models;

namespace RevenueRecognitionSystem.Infrastructure.Database.Configurations;

public class CompanyClientTypeConfiguration : IEntityTypeConfiguration<CompanyClient>
{
    public void Configure(EntityTypeBuilder<CompanyClient> builder)
    {
        builder.ToTable("company_clients");
        builder.HasBaseType<Client>();
        
        builder.Property(c => c.Name)
            .HasMaxLength(30)
            .IsRequired();
        
        builder.Property(c => c.KrsNumber)
            .HasMaxLength(10)
            .IsRequired();
    }
}