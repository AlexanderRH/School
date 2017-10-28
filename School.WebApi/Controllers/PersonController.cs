using Microsoft.AspNetCore.Mvc;
using School.UnitOfWork;
using School.Models;

namespace School.WebApi.Controllers
{
    [Route("api/Person")]
    public class PersonController : BaseController
    {
        public PersonController(IUnitOfWork unit) : base(unit)
        {
        }

        public IActionResult GetList()
        {
            return Ok(_unit.Person.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.Person.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Person.Insert(person));

            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (ModelState.IsValid && _unit.Person.Update(person))
                return Ok(new { Message = "The person is updated" });

            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Person person)
        {
            if (person.PersonID > 0)
                return Ok(_unit.Person.Delete(person));

            return BadRequest(new { Message = "Incorrect data." });
        }
    }
}
