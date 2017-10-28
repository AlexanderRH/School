using Microsoft.AspNetCore.Mvc;
using School.UnitOfWork;
using School.Models;

namespace School.WebApi.Controllers
{
    [Route("api/StudentGrade")]
    public class StudentGradeController : BaseController
    {
        public StudentGradeController(IUnitOfWork unit) : base(unit)
        {
        }

        public IActionResult GetList()
        {
            return Ok(_unit.StudentGrade.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.StudentGrade.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] StudentGrade studentGrade)
        {
            if (ModelState.IsValid)
                return Ok(_unit.StudentGrade.Insert(studentGrade));

            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] StudentGrade studentGrade)
        {
            if (ModelState.IsValid && _unit.StudentGrade.Update(studentGrade))
                return Ok(new { Message = "The student grade is updated" });

            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] StudentGrade studentGrade)
        {
            if (studentGrade.EnrollmentID > 0)
                return Ok(_unit.StudentGrade.Delete(studentGrade));

            return BadRequest(new { Message = "Incorrect data." });
        }
    }
}
