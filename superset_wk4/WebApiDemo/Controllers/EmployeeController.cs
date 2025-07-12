using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SwaggerDemo.Controllers
{
    [Route("api/emp")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<string>> GetEmployees()
        {
            return new string[] { "John", "Doe", "Jane" };
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public IActionResult AddEmployee([FromBody] string employee)
        {
            return Created("", $"Employee {employee} added.");
        }

        [HttpGet("all")]
        [ActionName("AllEmployees")]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            return new string[] { "All", "Employees", "Listed" };
        }
    }
}
