using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myprogramApi.Data;
using myprogramApi.Models;

namespace myprogramApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly MyProgramDbContext _myProgramDbContext;

        public EmployeesController(MyProgramDbContext myProgramDbContext)
        {
            _myProgramDbContext = myProgramDbContext;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllEmployees()
        {
         var employees = await   _myProgramDbContext.Employees.ToListAsync();
            return Ok(employees);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
        {
            employeeRequest.Id = Guid.NewGuid();
           await _myProgramDbContext.Employees.AddAsync(employeeRequest);
            await _myProgramDbContext.SaveChangesAsync();
            return Ok(employeeRequest);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employee = await _myProgramDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id,
            Employee updateEmployeeRequest)
        {
            var employee = await _myProgramDbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.Name = updateEmployeeRequest.Name;
            employee.Email = updateEmployeeRequest.Email;
            employee.Salary = updateEmployeeRequest.Salary;
            employee.Phone = updateEmployeeRequest.Phone;
            employee.Department = updateEmployeeRequest.Department;

            await _myProgramDbContext.SaveChangesAsync();
            return Ok(employee);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _myProgramDbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            _myProgramDbContext.Employees.Remove(employee);
            await _myProgramDbContext.SaveChangesAsync();
            return Ok(employee);
        }
    }
   
}
