using System;
using HumanResources.Domain.Entities;

namespace HumanResources.Domain.ServiceLayer.Entities
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public void UpdateContactInfo(Employee employee, ContactInfo contactInfo)
        {
            if (employee != null && contactInfo != null)
            {
                employee.UpdateContactInfo(contactInfo);
                _employeeRepository.Save();
            }
            else
                throw new ArgumentException();
        }

        public void AddEmployee(Employee employee)
        {
            _employeeRepository.AddEmployee(employee);
            _employeeRepository.Save();
        }
    }
}
