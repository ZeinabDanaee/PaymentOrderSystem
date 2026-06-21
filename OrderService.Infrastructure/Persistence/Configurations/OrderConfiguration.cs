using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Table name (optional)
            builder.ToTable("Orders");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.CustomerId)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.TotalAmount)
                   .HasPrecision(18, 2);

            builder.Property(x => x.CreatedAt)
                   .IsRequired();

            builder.Property(x => x.Status)
                   .IsRequired();

            // Relationship (1 to many)
            builder.HasMany(x => x.Items)
                   .WithOne()
                   .HasForeignKey(x => x.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
