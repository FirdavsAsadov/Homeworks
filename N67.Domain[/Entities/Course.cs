using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N67.Domain_.Entities
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public Guid TeacherId { get; set; }
        public virtual User Teacher { get; set; }
        public virtual ICollection<CourseStudent> CourseStudents { get;}
    }
}
