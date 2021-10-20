using Employee_Profile.Context;
using Employee_Profile.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Profile.Services
{
    public class EntityDB:ControllerBase
    {
        public EmployeeContext _employeeContext { get; set; }
       
        public EntityDB(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext?? throw ArgumentNullException(nameof(employeeContext));
        }
        private Exception ArgumentNullException(string v)
        {
            throw new NotImplementedException();
        }

        public IActionResult UpdateEmployee(int id, Employee_Entity emp)
        {
            var entity = _employeeContext.entity.FirstOrDefault(c => c.Empoyee_Id == id);
            entity.Contact = emp.Contact;
            entity.Name = emp.Name;
            entity.DOJ = emp.DOJ;
            entity.Email = emp.Email;
            entity.Gender = emp.Gender;
            if (_employeeContext.SaveChanges() > 0)
                return Accepted("Row Updated");
            return Forbid("Entity Created but Either DataBase Not Found or Not Connected");
        }

        public IEnumerable<Employee_Entity> GetEmployee()
        {
            return _employeeContext.entity.ToList();
        }
        public IActionResult AddEmployee(Employee_Entity emp)
        {
            _employeeContext.entity.Add(emp);
            if(_employeeContext.SaveChanges()>0)
            return Accepted("Row Created");
            return Forbid("Entity Created but Either DataBase Not Found or Not Connected");
        }
        public IActionResult GetEmployee(int id)
        {
            var entity=_employeeContext.entity.FirstOrDefault(c => c.Empoyee_Id == id);
            if (entity == null)
                return NotFound();
            return Ok(entity);
        }
        public IActionResult DeleteEmployee(int id)
        {
            var entity = _employeeContext.entity.FirstOrDefault(c => c.Empoyee_Id == id);
            if (entity == null)
                return NotFound($"Employee with Id {id} Not Found");
            _employeeContext.entity.Remove(entity);
            _employeeContext.SaveChanges();
            return NoContent();
        }

    }
}
