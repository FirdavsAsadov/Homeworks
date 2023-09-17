using System.Collections.Generic;

namespace N40_CT_Task1.Interfeyses
{
    public interface IStudentService
    {
        Student Create(Student student);
        Student Update(Student student);
        bool Delete(int id);
        Student GetById(int id);
        IEnumerable<Student> GetAll();
    }
}