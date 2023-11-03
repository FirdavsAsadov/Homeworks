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
    public class CourseStudentConfiguration : IEntityTypeConfiguration<CourseStudent>
    {
        public void Configure(EntityTypeBuilder<CourseStudent> builder)
        {
            builder.HasKey(courseStudent => new { courseStudent.CourseId, courseStudent.StudentId });
            builder.HasOne(x => x.Course).WithMany(x => x.Students).HasForeignKey(x => x.CourseId);
            builder.HasOne(x => x.Student).WithMany(x => x.StudentCourses).HasForeignKey(c => c.StudentId);
        }
    }
}
