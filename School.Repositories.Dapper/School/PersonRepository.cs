using Dapper;
using School.Models;
using School.Repositories.School;
using System.Data.SqlClient;

namespace School.Repositories.Dapper.School
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(string connectionString) : base(connectionString)
        {
        }

        public Person ValidaterPerson(string email, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@email", email);
                parameters.Add("@password", password);

                return connection.QueryFirstOrDefault<Person>(
                        "dbo.ValidatePerson",
                        parameters,
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
