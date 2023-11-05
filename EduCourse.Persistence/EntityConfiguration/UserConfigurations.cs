using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N67.Domain_.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCourse.Persistence.EntityConfiguration
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.FirstName).IsRequired().HasMaxLength(256);
            builder.Property(user => user.LastName).IsRequired().HasMaxLength(256);
        }
    }
}
