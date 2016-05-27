using System;
using HumanResources.Domain.Entities;

namespace HumanResources.Domain.ServiceLayer.Entities
{
    public class PersonnelDepartmentService
    {
        private readonly PersonnelDepartmentRepository _personnelDepartmentRepository;

        public PersonnelDepartmentService()
        {
            _personnelDepartmentRepository = new PersonnelDepartmentRepository();
        }

        public void AddEmployeeToPersonnelDepartment(PersonnelDepartment personnelDepartment, Employee employee)
        {
            if (personnelDepartment != null && employee != null)
            {
                //personnelDepartment.AddEmployee(employee);
                _personnelDepartmentRepository.Save();
            }
            else
                throw new ArgumentNullException();
        }

        public void ReassignEmployeeTo(PersonnelDepartment firstPersonnelDept,
            PersonnelDepartment secondPersonnelDept,
            Employee employeeFromFirstPersonnelDept)
        {
            if (firstPersonnelDept != null && secondPersonnelDept != null &&
                employeeFromFirstPersonnelDept != null)
            {
              //  firstPersonnelDept.ReassignEmployeeTo(employeeFromFirstPersonnelDept,secondPersonnelDept);
                _personnelDepartmentRepository.Save();
              
            }
            else
                throw new ArgumentNullException();
        }

        public void UpdatePersonnelDepartmetInfo(PersonnelDepartment personnelDepartment)
        {
            if (personnelDepartment != null)
            {
                _personnelDepartmentRepository.UpdatePersonnelDepartment(personnelDepartment);
                _personnelDepartmentRepository.Save();
            }
            else
                throw new ArgumentNullException();
        }

        public void DeleteEmployee(PersonnelDepartment personnelDepartment, Employee employee)
        {
            if (personnelDepartment != null && employee != null)
            {
               // personnelDepartment.DeleteEmployee(employee);
                _personnelDepartmentRepository.Save();
            }
            else
                throw new ArgumentNullException();
        }

        public void ChangeSupervisor(PersonnelDepartment personnelDepartment, Employee newDeptSupervisor)
        {
            if (personnelDepartment != null && newDeptSupervisor != null)
            {
              //  personnelDepartment.ChangeSupervisor(newDeptSupervisor);
                _personnelDepartmentRepository.Save();
            }
            else
                throw new ArgumentNullException();
        }
    }
}
