using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    public class ReceiptDetailConfig : IEntityTypeConfiguration<ReceiptDetail>
    {
        public void Configure(EntityTypeBuilder<ReceiptDetail> builder)
        {
            builder.ToTable("ReceiptDetail");
            builder.HasKey(p => new { p.ReceiptID , p.BookID });
            builder.Property(p => p.Quantity).IsRequired();

            builder.HasOne(p => p.Book).WithMany(p => p.receiptDetailsB).HasForeignKey(p => p.BookID);
            builder.HasOne(p => p.Receipt).WithMany(p => p.receiptDetailsR).HasForeignKey(p => p.ReceiptID);
        }
    }
}
