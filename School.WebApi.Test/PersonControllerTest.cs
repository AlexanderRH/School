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
    public class PersonControllerTest
    {
        private readonly PersonController _personController;
        private readonly IUnitOfWork _unitMocked;

        public PersonControllerTest()
        {
            var unitMocked = new UnitOfWorkMocked();
            _unitMocked = unitMocked.GetInstance();
            _personController = new PersonController(_unitMocked);
        }

        [Fact(DisplayName = "[PersonController] GetAll")]
        public void Test_GetAll()
        {
            var result = _personController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Course>;
            model.Count.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "[PersonController] GetById")]
        public void Test_GetById()
        {
            var result = _personController.GetById(10) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact(DisplayName = "[PersonController] Post")]
        public void Test_Post()
        {
            var person = GetNewPerson();

            var result = _personController.Post(person) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact(DisplayName = "[PersonController] Put")]
        public void Test_Put()
        {
            var person = GetNewPerson();
            person.PersonID = 10;
            person.FirstName = "Alexander";

            var result = _personController.Put(person) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact(DisplayName = "[PersonController] Delete")]
        public void Test_Delete()
        {
            var person = GetNewPerson();
            var resultCreate = _personController.Post(person) as OkObjectResult;
            resultCreate.Should().NotBeNull();
            resultCreate.Value.Should().NotBeNull();

            var result = _personController.Delete(person) as OkObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        private Person GetNewPerson()
        {
            return new Person
            {
                LastName = "Rodrigue",
                FirstName = "Alexander",
                HireDate = DateTime.Now,
                EnrollmentDate = DateTime.Now,
                Email = "alexrod2121@gmail.com",
                Password = "123"
            };
        }
    }
}
