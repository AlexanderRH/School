using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using School.Mocked;
using School.Models;
using School.UnitOfWork;
using School.WebApi.Controllers;
using System;
using System.Collections.Generic;
using Xunit;

namespace School.WebApi.Test
{
    public class StudentGradeControllerTest
    {
        private readonly StudentGradeController _studentGradeController;
        private readonly IUnitOfWork _unitMocked;

        public StudentGradeControllerTest()
        {
            var unitMocked = new UnitOfWorkMocked();
            _unitMocked = unitMocked.GetInstance();
            _studentGradeController = new StudentGradeController(_unitMocked);
        }

        [Fact(DisplayName = "[StudentGradeController] GetAll")]
        public void Test_GetAll()
        {
            var result = _studentGradeController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Course>;
            model.Count.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "[StudentGradeController] GetById")]
        public void Test_GetById()
        {
            var result = _studentGradeController.GetById(10) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact(DisplayName = "[StudentGradeController] Post")]
        public void Test_Post()
        {
            var studentGrade = GetNewStudentGrade();

            var result = _studentGradeController.Post(studentGrade) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact(DisplayName = "[StudentGradeController] Put")]
        public void Test_Put()
        {
            var studentGrade = GetNewStudentGrade();
            studentGrade.EnrollmentID = 10;
            studentGrade.CourseID = 2;

            var result = _studentGradeController.Put(studentGrade) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact(DisplayName = "[StudentGradeController] Delete")]
        public void Test_Delete()
        {
            var studentGrade = GetNewStudentGrade();
            var resultCreate = _studentGradeController.Post(studentGrade) as OkObjectResult;
            resultCreate.Should().NotBeNull();
            resultCreate.Value.Should().NotBeNull();

            var result = _studentGradeController.Delete(studentGrade) as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        private StudentGrade GetNewStudentGrade()
        {
            return new StudentGrade
            {
                CourseID = 1,
                StudentID = 1,
                Grade = 10
            };
        }
    }
}
