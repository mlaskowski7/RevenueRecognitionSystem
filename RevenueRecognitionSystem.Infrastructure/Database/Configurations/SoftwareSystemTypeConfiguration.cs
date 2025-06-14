using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevenueRecognitionSystem.Domain.Models;

namespace RevenueRecognitionSystem.Infrastructure.Database.Configurations;

public class SoftwareSystemTypeConfiguration : IEntityTypeConfiguration<SoftwareSystem>
{
    public void Configure(EntityTypeBuilder<SoftwareSystem> builder)
    {
       builder.ToTable("software_systems");
       
       builder.HasKey(ss => ss.SoftwareSystemId);
       builder.Property(ss => ss.SoftwareSystemId)
           .ValueGeneratedOnAdd();
       
       builder.Property(ss => ss.Name)
           .HasMaxLength(30)
           .IsRequired();
       builder.Property(ss => ss.Description)
           .HasMaxLength(100)
           .IsRequired();
       builder.Property(ss => ss.Version)
           .HasMaxLength(20)
           .IsRequired();
       builder.Property(ss => ss.Category)
           .HasMaxLength(30)
           .IsRequired();
       builder.Property(ss => ss.IsSoldUpfront)
           .IsRequired();
       builder.Property(ss => ss.IsSoldAsSubscription)
           .IsRequired();
    }
}