using Employee_Profile.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Profile.Context
{
    public class EmployeeContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Employee_Entity> entity { get; set; }
        public EmployeeContext(DbContextOptions<EmployeeContext> option):base(option)
        {
            //Database.EnsureCreated();
        }
       


    }
}
