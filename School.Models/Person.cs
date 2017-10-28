using Dapper.Contrib.Extensions;
using System;

namespace School.Models
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
