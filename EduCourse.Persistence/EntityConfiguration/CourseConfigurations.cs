using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N67.Domain_.Entities;

namespace EduCourse.Persistence.EntityConfiguration;

public class CourseConfigurations : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasOne(course => course.Teacher)
            .WithMany(user => user.TeacherCourses)
            .HasForeignKey(course => course.TeacherId);
    }
}
