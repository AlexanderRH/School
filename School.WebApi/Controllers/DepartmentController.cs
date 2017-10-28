using Microsoft.AspNetCore.Mvc;
using School.UnitOfWork;
using School.Models;

namespace School.WebApi.Controllers
{
    [Route("api/Department")]
    public class DepartmentController : BaseController
    {
        public DepartmentController(IUnitOfWork unit) : base(unit)
        {
        }

        public IActionResult GetList()
        {
            return Ok(_unit.Department.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.Department.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Department department)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Department.Insert(department));

            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Department department)
        {
            if (ModelState.IsValid && _unit.Department.Update(department))
                return Ok(new { Message = "The department is updated" });

            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Department department)
        {
            if (department.DepartmentID > 0)
                return Ok(_unit.Department.Delete(department));

            return BadRequest(new { Message = "Incorrect data." });
        }
    }
}
