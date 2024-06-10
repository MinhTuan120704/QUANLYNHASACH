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
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.HasKey(p => p.EmployeeID);
            builder.Property(p => p.EmployeeID).UseIdentityColumn(1, 1);
            builder.Property(p => p.EmployeeName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.BirthDay).IsRequired();
            builder.Property(p => p.Phone).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(50).IsRequired();

            builder.HasOne(p => p.account).WithOne(p => p.Employee).HasForeignKey<Account>(p => p.EmployeeID);
            
        }
    }
}
