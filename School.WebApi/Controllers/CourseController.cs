using Microsoft.AspNetCore.Mvc;
using School.UnitOfWork;
using School.Models;

namespace School.WebApi.Controllers
{
    [Route("api/Course")]
    public class CourseController : BaseController
    {
        public CourseController(IUnitOfWork unit) : base(unit)
        {
        }

        public IActionResult GetList()
        {
            return Ok(_unit.Course.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.Course.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Course course)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Course.Insert(course));

            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Course course)
        {
            if (ModelState.IsValid && _unit.Course.Update(course))
                return Ok(new { Message = "The course is updated" });

            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Course course)
        {
            if (course.CourseID > 0)
                return Ok(_unit.Course.Delete(course));

            return BadRequest(new { Message = "Incorrect data." });
        }
    }
}
