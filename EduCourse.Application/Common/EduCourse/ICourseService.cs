using N67.Domain_.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EduCourse.Application.Common.EduCourse
{
    public interface ICourseService
    {
        ValueTask<Course> Create(Course course);
        ValueTask<Course> Update(Course course);
        ValueTask<Course> Delete(string courseName);
        ValueTask<Course> GetById(Guid Id);
        ValueTask<Course> Get(Expression<Func<Course, bool>> predicate);
    }
}
