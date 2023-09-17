using System;

namespace N40_CT_Task1
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProjectPath { get; set;}
        public string CrmId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Student(int id, string firstName, string lastName, string projectPath, string crmId, DateTime createdAt, DateTime? updatedAt)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            ProjectPath = projectPath;
            CrmId = crmId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}