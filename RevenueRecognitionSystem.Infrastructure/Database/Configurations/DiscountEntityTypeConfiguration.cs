using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevenueRecognitionSystem.Domain.Models;

namespace RevenueRecognitionSystem.Infrastructure.Database.Configurations;

public class DiscountEntityTypeConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
       builder.ToTable("discounts");
       
       builder.HasKey(d => d.DiscountId);
       builder.Property(d => d.Description).ValueGeneratedOnAdd();
       
       builder.Property(d => d.Percentage)
           .IsRequired();
       builder.Property(d => d.Name)
           .HasMaxLength(20)
           .IsRequired();
       builder.Property(d => d.Description)
           .HasMaxLength(100)
           .IsRequired();
       builder.Property(d => d.StartDate)
           .IsRequired();
       builder.Property(d => d.EndDate)
           .IsRequired();

       builder.ToTable(t =>
           t.HasCheckConstraint("CK_Discount_Percentage_Range", "[Percentage] >= 1 AND [Percentage] <= 99"));
    }
}