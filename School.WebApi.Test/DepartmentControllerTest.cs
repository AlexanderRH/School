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
    public class DepartmentControllerTest
    {
        private readonly DepartmentController _departmentController;
        private readonly IUnitOfWork _unitMocked;

        public DepartmentControllerTest()
        {
            var unitMocked = new UnitOfWorkMocked();
            _unitMocked = unitMocked.GetInstance();
            _departmentController = new DepartmentController(_unitMocked);
        }

        [Fact(DisplayName = "[DepartmentController] GetAll")]
        public void Test_GetAll()
        {
            var result = _departmentController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Course>;
            model.Count.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "[DepartmentController] GetById")]
        public void Test_GetById()
        {
            var result = _departmentController.GetById(10) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact(DisplayName = "[DepartmentController] Post")]
        public void Test_Post()
        {
            var department = GetNewDepartment();

            var result = _departmentController.Post(department) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact(DisplayName = "[DepartmentController] Put")]
        public void Test_Put()
        {
            var department = GetNewDepartment();
            department.DepartmentID = 10;
            department.Name = "New Department";

            var result = _departmentController.Put(department) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact(DisplayName = "[DepartmentController] Delete")]
        public void Test_Delete()
        {
            var department = GetNewDepartment();
            var resultCreate = _departmentController.Post(department) as OkObjectResult;
            resultCreate.Should().NotBeNull();
            resultCreate.Value.Should().NotBeNull();

            var result = _departmentController.Delete(department) as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        private Department GetNewDepartment()
        {
            return new Department
            {
                Name = "New Department",
                Budget = 0,
                StartDate = DateTime.Now,
                Administrator = 0
            };
        }
    }
}
