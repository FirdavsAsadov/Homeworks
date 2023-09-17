using System;
using System.Collections.Generic;
using System.Linq;
using N40_CT_Task1.Data;
using N40_CT_Task1.Interfeyses;

namespace N40_CT_Task1.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly Efcorecontext _efcorecontext;
        public StudentService(Efcorecontext efcorecontext)
        {
            _efcorecontext = efcorecontext;
        }
        public Student Create(Student student)
        {
            var existingStudent = _efcorecontext.Students.FirstOrDefault(x => x.Id == student.Id);
            if(existingStudent != null)
            {
                throw new ArgumentException("Bu Student avval ro'yxatdan o'tgan!!");
            }
            else
            {
                _efcorecontext.Add(student);
                _efcorecontext.SaveChanges();
                return student;
            }
        }

        public Student Update(Student student)
        {
            var updatingStudents = _efcorecontext.Students.FirstOrDefault(x => x.Id.Equals(student.Id));
            if(updatingStudents == null)
            {
                throw new ArgumentException(" Bu Id dagi user topilmadi!!");
            }
            else
            {
                updatingStudents.FirstName = student.FirstName;
                updatingStudents.LastName = student.LastName;
                updatingStudents.UpdatedAt = DateTime.Now;
                updatingStudents.ProjectPath = student.ProjectPath;
                updatingStudents.CrmId = student.CrmId;
                _efcorecontext.SaveChanges();
                return student;
            }
        }

        public bool Delete(int id)
        {
            var deletingStudent = _efcorecontext.Students.FirstOrDefault(x => x.Id == id);
            if(deletingStudent != null)
            {
                _efcorecontext.Remove(deletingStudent);
                _efcorecontext.SaveChanges();
                return true;
            }
            return false;
        }

        public Student GetById(int id)
        {
            var gettingStudent = _efcorecontext.Students.FirstOrDefault(x => x.Id.Equals(id));
            if(gettingStudent != null)
            {
                return gettingStudent;
            }
            return null;
        }

        public IEnumerable<Student> GetAll()
        {
            return _efcorecontext.Students;
        }
    }
}