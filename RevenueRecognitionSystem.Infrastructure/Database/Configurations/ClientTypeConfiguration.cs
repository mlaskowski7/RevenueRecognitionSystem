using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevenueRecognitionSystem.Domain.Models;

namespace RevenueRecognitionSystem.Infrastructure.Database.Configurations;

public class ClientTypeConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("clients");

        builder.HasKey(c => c.ClientId);
        builder.Property(c => c.ClientId)
            .ValueGeneratedOnAdd();
        
        builder.Property(c => c.Address)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(c => c.PhoneNumber)
            .HasMaxLength(30)
            .IsRequired();
        builder.Property(c => c.Email)
            .HasMaxLength(50)
            .IsRequired();
    }
}