using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(p => p.AccountID);
            builder.Property(p => p.AccountID).UseIdentityColumn(1, 1);
            builder.Property(p => p.AccountName).IsRequired();
            builder.Property(p => p.Password).HasMaxLength(32).IsRequired();
            builder.Property(p => p.Position).IsRequired(); 
        }
    }
}
