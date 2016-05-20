using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonnelDepartment
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class PersonnelDepartment
    {
       
        private readonly List<Employee> employees;

        public PersonnelDepartment()
        {
            employees = new List<Employee>();
        }
        public string Title { get; set; } 
        public bool  
 
        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
            employee.PersonnelDepartment = this;
        }


        public IEnumerable<Employee> Employees
        {
            get { return employees; }
        }

        public void UpdateEmployee(int employeeId)
        {

        }
    }
}
