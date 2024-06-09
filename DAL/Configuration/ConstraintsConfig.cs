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
    public class ConstraintsConfig : IEntityTypeConfiguration<Constraints>
    {
        public void Configure(EntityTypeBuilder<Constraints> builder)
        {
            builder.ToTable("Constraints");
            builder.HasKey(p => p.ConstraintID);
            builder.Property(p => p.ConstraintID).UseIdentityColumn(1, 1);
            builder.Property(p => p.ConstraintName).IsRequired();
            builder.Property(p => p.ConstraintValue).IsRequired();
        }
    }
}
