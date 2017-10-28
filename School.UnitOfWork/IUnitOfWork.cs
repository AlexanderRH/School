using School.Repositories.School;
using System;

namespace School.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICourseRepository Course { get; }
        IDepartmentRepository Department { get; }
        IPersonRepository Person { get; }
        IStudentGradeRepository StudentGrade { get; }
    }
}
