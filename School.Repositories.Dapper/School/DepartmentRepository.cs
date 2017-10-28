using School.Models;
using School.Repositories.School;

namespace School.Repositories.Dapper.School
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
