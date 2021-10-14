using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiTest.Models;

namespace WebApiTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {     
        private readonly ILogger<EmployeesController> _logger;
        private readonly demoContext _demoContext;
        public EmployeesController(ILogger<EmployeesController> logger,demoContext demoContext)
        {
            _logger = logger;
            _demoContext = demoContext;
        }

        [HttpGet("GetEmployeesData")]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            try
            {
                return _demoContext.Employees;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost("CreateEmployeesData")]
        public ActionResult Create(Employee employee)
        {            
            try
            {                
                _demoContext.Employees.Add(employee);
                _demoContext.SaveChanges();
                
            }
            catch (Exception ex)
            {
                return NoContent();
            }
            return Ok();

        }

    }
}
