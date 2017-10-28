using AutoFixture;
using Moq;
using School.Models;
using School.Repositories.School;
using School.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace School.Mocked
{
    public class UnitOfWorkMocked
    {
        private List<Course> _course;
        private List<Department> _department;
        private List<Person> _person;
        private List<StudentGrade> _studentGrade;

        public UnitOfWorkMocked()
        {
            _course = Courses();
            _department = Departments();
            _person = Persons();
            _studentGrade = StudentGrades();
        }

        public IUnitOfWork GetInstance()
        {
            var mocked = new Mock<IUnitOfWork>();
            mocked.Setup(u => u.Course).Returns(CourseRepositoryMocked());

            return mocked.Object;
        }

        private ICourseRepository CourseRepositoryMocked()
        {
            var customerMocked = new Mock<ICourseRepository>();

            customerMocked.Setup(c => c.GetList())
                            .Returns(_course);

            customerMocked.Setup(c => c.Insert(It.IsAny<Course>()))
                            .Callback<Course>(c => _course.Add(c))
                            .Returns<Course>(c => c.CourseID);

            customerMocked.Setup(c => c.Update(It.IsAny<Course>()))
                            .Callback<Course>(c =>
                            {
                                _course.RemoveAll(cus => cus.CourseID == c.CourseID);
                                _course.Add(c);
                            }
                                )
                            .Returns(true);

            customerMocked.Setup(c => c.Delete(It.IsAny<Course>()))
                            .Callback<Course>(c => _course.RemoveAll(cus => cus.CourseID == c.CourseID))
                            .Returns(true);

            customerMocked.Setup(c => c.GetById(It.IsAny<int>()))
                            .Returns((int id) => _course.FirstOrDefault(cus => cus.CourseID == id));

            return customerMocked.Object;
        }

        private IDepartmentRepository DepartmentRepositoryMocked()
        {
            var departmentMocked = new Mock<IDepartmentRepository>();

            departmentMocked.Setup(c => c.GetList())
                            .Returns(_department);

            departmentMocked.Setup(d => d.Insert(It.IsAny<Department>()))
                            .Callback<Department>(d => _department.Add(d))
                            .Returns<Department>(d => d.DepartmentID);

            departmentMocked.Setup(d => d.Update(It.IsAny<Department>()))
                            .Callback<Department>(d =>
                            {
                                _department.RemoveAll(dep => dep.DepartmentID == d.DepartmentID);
                                _department.Add(d);
                            }
                                )
                            .Returns(true);

            departmentMocked.Setup(d => d.Delete(It.IsAny<Department>()))
                            .Callback<Department>(d => _department.RemoveAll(dep => dep.DepartmentID == d.DepartmentID))
                            .Returns(true);

            departmentMocked.Setup(c => c.GetById(It.IsAny<int>()))
                            .Returns((int id) => _department.FirstOrDefault(dep => dep.DepartmentID == id));

            return departmentMocked.Object;
        }

        private IPersonRepository PersonRepositoryMocked()
        {
            var personMocked = new Mock<IPersonRepository>();

            personMocked.Setup(p => p.GetList())
                            .Returns(_person);

            personMocked.Setup(p => p.Insert(It.IsAny<Person>()))
                            .Callback<Person>(p => _person.Add(p))
                            .Returns<Person>(p => p.PersonID);

            personMocked.Setup(p => p.Update(It.IsAny<Person>()))
                            .Callback<Person>(p =>
                            {
                                _person.RemoveAll(per => per.PersonID == p.PersonID);
                                _person.Add(p);
                            }
                                )
                            .Returns(true);

            personMocked.Setup(p => p.Delete(It.IsAny<Person>()))
                            .Callback<Person>(p => _person.RemoveAll(per => per.PersonID == p.PersonID))
                            .Returns(true);

            personMocked.Setup(p => p.GetById(It.IsAny<int>()))
                            .Returns((int id) => _person.FirstOrDefault(per => per.PersonID == id));

            return personMocked.Object;
        }

        private IStudentGradeRepository StudentGradeRepositoryMocked()
        {
            var studentGradeMocked = new Mock<IStudentGradeRepository>();

            studentGradeMocked.Setup(s => s.GetList())
                            .Returns(_studentGrade);

            studentGradeMocked.Setup(s => s.Insert(It.IsAny<StudentGrade>()))
                            .Callback<StudentGrade>(s => _studentGrade.Add(s))
                            .Returns<StudentGrade>(s => s.EnrollmentID);

            studentGradeMocked.Setup(s => s.Update(It.IsAny<StudentGrade>()))
                            .Callback<StudentGrade>(s =>
                            {
                                _studentGrade.RemoveAll(stu => stu.EnrollmentID == s.EnrollmentID);
                                _studentGrade.Add(s);
                            }
                                )
                            .Returns(true);

            studentGradeMocked.Setup(s => s.Delete(It.IsAny<StudentGrade>()))
                            .Callback<StudentGrade>(s => _studentGrade.RemoveAll(stu => stu.EnrollmentID == s.EnrollmentID))
                            .Returns(true);

            studentGradeMocked.Setup(s => s.GetById(It.IsAny<int>()))
                            .Returns((int id) => _studentGrade.FirstOrDefault(stu => stu.EnrollmentID == id));

            return studentGradeMocked.Object;
        }

        private List<Course> Courses()
        {
            var fixture = new Fixture();
            var courses = fixture.CreateMany<Course>(50).ToList();

            for (int i = 0; i < 50; i++)
            {
                courses[i].CourseID = i + 1;
            }

            return courses;
        }

        private List<Department> Departments()
        {
            var fixture = new Fixture();
            var departments = fixture.CreateMany<Department>(50).ToList();

            for (int i = 0; i < 50; i++)
            {
                departments[i].DepartmentID = i + 1;
            }

            return departments;
        }

        private List<Person> Persons()
        {
            var fixture = new Fixture();
            var persons = fixture.CreateMany<Person>(50).ToList();

            for (int i = 0; i < 50; i++)
            {
                persons[i].PersonID = i + 1;
            }

            return persons;
        }

        private List<StudentGrade> StudentGrades()
        {
            var fixture = new Fixture();
            var studentGrades = fixture.CreateMany<StudentGrade>(50).ToList();

            for (int i = 0; i < 50; i++)
            {
                studentGrades[i].EnrollmentID = i + 1;
            }

            return studentGrades;
        }
    }
}
