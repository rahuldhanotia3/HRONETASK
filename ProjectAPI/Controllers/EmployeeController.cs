using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.DbData;
using ProjectAPI.Models;

namespace ProjectAPI.Controllers
{
    [ApiController]
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        public EmployeeDbContext employeeDbContext;
        public EmployeeController(EmployeeDbContext context)
        {
            this.employeeDbContext = context;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Employee> result;
            
            result = employeeDbContext.Employees.FromSqlRaw("EmployeeGetAll").ToList();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(Employee e)
        {
            var result = employeeDbContext.Database.ExecuteSqlRaw("EXEC EmployeeCreate @id, @name, @dept",
                new SqlParameter("@id", e.Id),
                new SqlParameter("@name", e.Name),
                new SqlParameter("@dept", e.Department));

            if (result > 0)
                return Ok(e);
            else
                return BadRequest(-1);
        }
    }
}
