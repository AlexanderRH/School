using School.Repositories.School;
using School.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Repositories.Dapper.School
{
    public class SchoolUnitOfWork : IUnitOfWork
    {
        public SchoolUnitOfWork(string connectionString)
        {
            Course = new CourseRepository(connectionString);
            Department = new DepartmentRepository(connectionString);
            Person = new PersonRepository(connectionString);
            StudentGrade = new StudentGradeRepository(connectionString);
        }

        public ICourseRepository Course { get; private set; }

        public IDepartmentRepository Department { get; private set; }

        public IPersonRepository Person { get; private set; }

        public IStudentGradeRepository StudentGrade { get; private set; }
    }
}
