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
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.Property(x => x.Definition).HasMaxLength(400).IsRequired();
            builder.HasData(new AppRole[]
            {
                new()
                {
                    Definition = "Admin",
                    Id=1
                },
                new()
                {
                    Definition = "Member",
                    Id=2
                }
            });
        }
    }
}
