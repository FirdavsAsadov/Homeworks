namespace N67.Domain_.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public virtual ICollection<Course> TeacherCourses { get; set;}
        public virtual ICollection<CourseStudent> CoursStudents { get; set; }
    }
}
