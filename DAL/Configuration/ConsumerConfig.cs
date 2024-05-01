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
    public class ConsumerConfig : IEntityTypeConfiguration<Consumer>
    {
        public void Configure(EntityTypeBuilder<Consumer> builder)
        {
            builder.ToTable("Consumer");
            builder.HasKey(p => p.ConsumerID);
            builder.Property(p => p.ConsumerID).UseIdentityColumn(1, 1);
            builder.Property(p => p.ConsumerName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Address).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Phone).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Debt).IsRequired();
            builder.Property(p => p.Created).IsRequired();
        }
    }
}
