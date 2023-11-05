namespace EduCourse.Application.Common.EduCourse
{
    public interface ICourseProcessingService
    {
        ValueTask<bool> AddStudent(Guid courseId, Guid studentId);
    }
}