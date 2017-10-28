using School.Models;
using School.Repositories.School;

namespace School.Repositories.Dapper.School
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
