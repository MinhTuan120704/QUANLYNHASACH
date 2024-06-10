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
    public class ReceiptConfig : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.ToTable("Receipt");
            builder.HasKey(p => p.ReceiptID);
            builder.Property(p => p.ReceiptID).UseIdentityColumn(1, 1);
            builder.Property(p => p.ReceiptDate).IsRequired();
            builder.Property(p => p.Total).IsRequired();

            builder.HasOne(p => p.Employee).WithMany(p => p.Employeereceipt).HasForeignKey(p => p.EmployeeID);
        }
    }
}
