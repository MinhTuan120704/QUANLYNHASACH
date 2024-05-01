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
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");
            builder.HasKey(p => p.BookID);
            builder.Property(p => p.BookID).UseIdentityColumn(1, 1);
            builder.Property(p => p.BookName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.BookType).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Author).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Publisher).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Quantity).IsRequired();
            builder.Property(p => p.UnitPrice).IsRequired();
            builder.Property(p => p.UnitSoldPrice).IsRequired();
        }
    }
}
