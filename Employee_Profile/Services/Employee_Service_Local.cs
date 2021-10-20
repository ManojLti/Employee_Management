using Employee_Profile.Modules;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee_Profile.Entities;
using System.Text.RegularExpressions;

namespace Employee_Profile.Services
{
    public class Employee_Service_Local:ControllerBase
    {
        EntityDB _db { get; set; }

        public Employee_Service_Local(EntityDB db)
        {
            _db = db ?? throw ArgumentNullException(nameof(db));

        }
        private Exception ArgumentNullException(string v)
        {
            throw new NotImplementedException();
        }
        public static Boolean ValidateEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }
        public static Boolean ValidateContact(string Contact)
        {
            if(Contact.Length==10)
            return Contact.All(char.IsDigit);
            return false;
        }
        public static Boolean ValidateName(string Name)
        {
            return Name.All(char.IsLetter);
        }
        public static Boolean ValidateGender(string Gender)
        {
            if (Gender == null)
                return true;
            if(Gender.All(char.IsLetter))
            {
                if (Gender.ToLower().Equals("male")|| Gender.ToLower().Equals("female")|| Gender.ToLower().Equals("transgender"))
                    return true;
            }
            return false;
        }
        public static Boolean ValidateDOB(string DOB)
        {
            DateTime expectedDate;
            if (!DateTime.TryParse(DOB, out expectedDate))
            {
                return false;
            }
            else
            {
                try
                {
                    DateTime.Parse(DOB,
                      System.Globalization.CultureInfo.InvariantCulture);
                }
                catch(Exception e)
                {
                    return false;
                }
                
            }
            return true;
        }

        public Employee_Entity CreateEntity(Employee_Module emp)
        {
            Employee_Entity entity = new Employee_Entity()
            {
                Name = emp.Name,
                //Empoyee_Id = int.Parse(emp.Empoyee_Id),

                Contact = long.Parse(emp.Contact),
                Email = emp.Email,
                DOJ = DateTime.Now,
                DOB = DateTime.Parse(emp.DOB,
                         System.Globalization.CultureInfo.InvariantCulture),
                Gender = emp.Gender
            };
            return entity;

        }
        
        public IActionResult GetEmployee()
        {
            return Ok(_db.GetEmployee());

        }

        public IActionResult UpdateEmployee(int id,Employee_Module emp)
        {
            Employee_Entity entity = CreateEntity(emp);

            return _db.UpdateEmployee(id,entity);
        }
        public IActionResult GetEmployee(int id)
        {
            return _db.GetEmployee(id);
        }
        public IActionResult AddEmployee(Employee_Module emp)
        {
            if (!ValidateContact(emp.Contact))
                return BadRequest("Invalid Contact");
            if (!ValidateName(emp.Name))
                return BadRequest("Invalid Name");

            if (!ValidateEmail(emp.Email))
                return BadRequest("Invalid Email Id");
            if (!ValidateGender(emp.Gender))
                return BadRequest("Invalidate Gender");
            if (!ValidateDOB(emp.DOB))
                return BadRequest("Invalid DOB");
            Employee_Entity entity = CreateEntity(emp);

            return _db.AddEmployee(entity);
        }

        public IActionResult DeleteEmployee(int id)
        {
            return _db.DeleteEmployee(id);
        }
    }
}
