using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;
using WebApiDemo.Filters;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(CustomAuthFilter))]
    public class EmployeeController : ControllerBase
    {
        private List<Employee> _employees;

        public EmployeeController()
        {
            _employees = GetStandardEmployeeList();
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<Employee>), 200)]
        [ProducesResponseType(500)]
        public ActionResult<List<Employee>> GetStandard()
        {
            throw new Exception("Sample exception for testing.");
            return Ok(_employees);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee emp)
        {
            _employees.Add(emp);
            return Ok(emp);
        }

        
        [HttpPut]
        public ActionResult<Employee> UpdateEmployee([FromBody] Employee updatedEmp)
        {
            if (updatedEmp.Id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var emp = _employees.FirstOrDefault(e => e.Id == updatedEmp.Id);
            if (emp == null)
            {
                return BadRequest("Invalid employee id");
            }

            emp.Name = updatedEmp.Name;
            emp.Salary = updatedEmp.Salary;
            emp.Permanent = updatedEmp.Permanent;
            emp.Department = updatedEmp.Department;
            emp.Skills = updatedEmp.Skills;
            emp.DateOfBirth = updatedEmp.DateOfBirth;

            return Ok(emp);
        }


        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John",
                    Salary = 50000,
                    Permanent = true,
                    Department = new Department { Id = 1, Name = "HR" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "C#" },
                        new Skill { Id = 2, Name = "SQL" }
                    },
                    DateOfBirth = new DateTime(1990, 1, 1)
                }
            };
        }
    }
}