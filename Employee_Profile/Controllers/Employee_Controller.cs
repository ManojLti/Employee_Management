using Employee_Profile.Modules;
using Employee_Profile.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Profile.Controllers
{   [ApiController]
    [Route("api/employee")]
    public class Employee_Controller : ControllerBase
    {
        Employee_Service_Local _esl { get; set; }
        public Employee_Controller(Employee_Service_Local esl)
        {
            _esl = esl ?? throw ArgumentNullException(nameof(esl));
        }

        private Exception ArgumentNullException(string v)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetEmployee()
        {
            return Ok(_esl.GetEmployee());
        }
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            return _esl.GetEmployee(id);    
        }
        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee_Module emp)
        {
            
          return  _esl.AddEmployee(emp);

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            return _esl.DeleteEmployee(id);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateEmpoyee(int id,[FromBody] Employee_Module emp)
        {
            return _esl.UpdateEmployee(id, emp);
        }
    }
}
