using System;
using System.Collections.Generic;
using HumanResources.Domain.Entities;
using HumanResources.Domain.ServiceLayer.Entities;

namespace HumanResources.Domain.ServiceLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var newEmployeeService = new EmployeeService();
            var newL = new Employee { Role = Role.ProjectManager.ToString(), Surname = "Krutko", Name = "Irina"};
            newEmployeeService.UpdateContactInfo(newL, new ContactInfo("a@a", "73462846"));

            var newEr = new EmployeeRepository();
         //   Employee empL = newEr.GetEmployeeById(8);
            newEr.AddEmployee(newL);

            Console.Write("Вышли");
            Console.Read();
        }
    }
}
