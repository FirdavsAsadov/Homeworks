using EduCourse.Application.Common.EduCourse;
using N67.Domain_.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EduCourse.Infrastructure.Common.EduCourse.Services
{
    public class CourseService : ICourseService
    {
        public ValueTask<Course> Create(Course course)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Course> Delete(string courseName)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Course> Get(Expression<Func<Course, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Course> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Course> Update(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
