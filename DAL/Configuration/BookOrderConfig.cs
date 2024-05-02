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
    internal class BookOrderConfig : IEntityTypeConfiguration<BookOrder>
    {
        public void Configure(EntityTypeBuilder<BookOrder> builder)
        {
            builder.ToTable("BookOrder");
            builder.HasKey(p => new { p.OrderID, p.BookID});
            builder.Property(p => p.Quantity).IsRequired(); 

            builder.HasOne(p => p.Book).WithMany(p => p.bookOrdersB).HasForeignKey(p => p.BookID);
            builder.HasOne(p => p.Order).WithMany(p => p.bookOrdersO).HasForeignKey(p => p.OrderID);
        }
    }
}
