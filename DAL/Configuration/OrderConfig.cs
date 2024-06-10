using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(p => p.OrderID);
            builder.Property(p => p.OrderID).UseIdentityColumn(1, 1);
            builder.Property(p => p.Date).IsRequired();
            builder.Property(p => p.TotalValue).IsRequired();
            builder.Property(p => p.PaidValue).IsRequired();
            builder.Property(p => p.RemainingValue).IsRequired();
        }
    }
}
