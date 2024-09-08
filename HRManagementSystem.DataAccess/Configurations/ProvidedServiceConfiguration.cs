using HRManagementSystem.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.DataAccess.Configurations
{
    public class ProvidedServiceConfiguration : IEntityTypeConfiguration<ProvidedService>
    {
        public void Configure(EntityTypeBuilder<ProvidedService> builder)
        {
            builder.Property(x => x.Description).HasColumnType("ntext").IsRequired();
            builder.Property(x => x.ImagePath).HasMaxLength(400).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(250).IsRequired();
        }
    }
}
