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
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();   
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();   
            builder.Property(x => x.Username).HasMaxLength(300).IsRequired();   
            builder.Property(x => x.PhoneNumber).HasMaxLength(20).IsRequired();   
            builder.Property(x => x.Password).HasMaxLength(50).IsRequired();
            builder.HasOne(x => x.Gender).WithMany(x => x.AppUsers).HasForeignKey(x => x.GenderId);
        }
    }
}
