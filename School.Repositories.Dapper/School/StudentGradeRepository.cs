using School.Models;
using School.Repositories.School;

namespace School.Repositories.Dapper.School
{
    public class StudentGradeRepository : Repository<StudentGrade>, IStudentGradeRepository
    {
        public StudentGradeRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
