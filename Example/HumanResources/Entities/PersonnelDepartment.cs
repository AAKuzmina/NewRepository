using System;
using System.Collections.Generic;

using System.Linq;

namespace HumanResources.Domain.Entities
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
  
    public class PersonnelDepartment
    {
        private readonly List<Employee> _employees;

        public PersonnelDepartment(string deptTitle, Employee deptSupervisor)
        {
            Title = deptTitle;
            deptSupervisor.MarkAsEmployed();
            DeptSupervisor = deptSupervisor;

            _employees = new List<Employee>();
        }

        public int Id { get; protected set; }
        public string Title { get; protected set; }

        public Employee DeptSupervisor { get; protected set; }

        public IEnumerable<Employee> Employees
        {
            get { return _employees; }
        }

        public void AddEmployee(Employee employee)
        {
            if (employee.IsEmployed == false)
            {
                employee = employee.MarkAsEmployed();
                _employees.Add(employee);
            }
            else
                throw new ArgumentException("Employee belongs to another department");
        }

        public void DeleteEmployee(Employee employee)
        {
            if (!_employees.Contains(employee) || employee.IsEmployed == false)
                throw new ArgumentException("Employee do not contain into dept");

            _employees.Remove(employee);
            employee.MarkAsUnemployed();
        }

        public void ReassignEmployeeTo(Employee employee, PersonnelDepartment otherPersonnelDepartment)
        {
            DeleteEmployee(employee);

            otherPersonnelDepartment.AddEmployee(employee);
        }

        public void UpdatePersonnelDepartmetInfo(PersonnelDepartmentInfo personnelDepartmentInfo)
        {
            if (personnelDepartmentInfo == null)
                throw new ArgumentNullException(nameof(personnelDepartmentInfo),
                    "Personnel department info can't be null");

            Title = personnelDepartmentInfo.Title;
            ChangeSupervisor(personnelDepartmentInfo.DeptSupervisor);
        }

        public Dictionary<string, List<Employee>> ShowHierarchyPersonnelDepartment()
        {
            var hierarchyPersonnelDepartment = new Dictionary<string, List<Employee>>
            {
                {
                    "Department superviser: ",
                    new List<Employee>
                    {
                        DeptSupervisor
                    }
                },
                {
                    "Employees: ",
                    Employees.Select(employee => employee).ToList()
                }
            };

            return hierarchyPersonnelDepartment;
        }

        public void ChangeSupervisor(Employee newDeptSupervisor)
        {
            if (!newDeptSupervisor.Role.Equals(Role.ProjectManager))
                throw new ArgumentException();

            newDeptSupervisor.MarkAsEmployed();
            DeptSupervisor.MarkAsUnemployed();
            DeptSupervisor = newDeptSupervisor;
        }
    }
}