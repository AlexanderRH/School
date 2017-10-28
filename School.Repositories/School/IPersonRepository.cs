using School.Models;

namespace School.Repositories.School
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person ValidaterPerson(string email, string password);
    }
}
