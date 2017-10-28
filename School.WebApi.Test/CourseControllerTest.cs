using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using School.Mocked;
using School.Models;
using School.UnitOfWork;
using School.WebApi.Controllers;
using System.Collections.Generic;
using Xunit;

namespace School.WebApi.Test
{
    public class CourseControllerTest
    {
        private readonly CourseController _courseController;
        private readonly IUnitOfWork _unitMocked;

        public CourseControllerTest()
        {
            var unitMocked = new UnitOfWorkMocked();
            _unitMocked = unitMocked.GetInstance();
            _courseController = new CourseController(_unitMocked);
        }

        [Fact(DisplayName = "[CourseController] GelAll")]
        public void Test_GetAll()
        {
            var result = _courseController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Course>;
            model.Count.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "[CourseController] GetById")]
        public void Test_GetById()
        {
            var result = _courseController.GetById(10) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact(DisplayName = "[CourseController] Post")]
        public void Test_Post()
        {
            var course = GetNewCourse();

            var result = _courseController.Post(course) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact(DisplayName = "[CourseController] Put")]
        public void Test_Put()
        {
            var course = GetNewCourse();
            course.CourseID = 10;
            course.Title = "New Course";

            var result = _courseController.Put(course) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact(DisplayName = "[CourseController] Delete")]
        public void Test_Delete()
        {
            var course = GetNewCourse();
            var resultCreate = _courseController.Post(course) as OkObjectResult;
            resultCreate.Should().NotBeNull();
            resultCreate.Value.Should().NotBeNull();

            var result = _courseController.Delete(course) as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        private Course GetNewCourse()
        {
            return new Course
            {
                Title = "New Course",
                Credits = 10,
                DepartmentID = 1
            };
        }
    }
}
