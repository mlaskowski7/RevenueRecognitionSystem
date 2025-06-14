using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevenueRecognitionSystem.Domain.Models;

namespace RevenueRecognitionSystem.Infrastructure.Database.Configurations;

public class IndividualClientTypeConfiguration : IEntityTypeConfiguration<IndividualClient>
{
    public void Configure(EntityTypeBuilder<IndividualClient> builder)
    {
        builder.ToTable("individual_clients");
        builder.HasBaseType<Client>();
        
        builder.Property(c => c.FirstName)
            .HasMaxLength(30)
            .IsRequired();
        
        builder.Property(c => c.LastName)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(c => c.Pesel)
            .HasMaxLength(11)
            .IsRequired();
        
        builder.Property(c => c.IsDeleted)
            .HasDefaultValue(false)
            .IsRequired();
    }
}