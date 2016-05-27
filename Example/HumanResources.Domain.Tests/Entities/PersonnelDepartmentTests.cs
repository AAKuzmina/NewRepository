using System;
using HumanResources.Domain.Entities;
using Xunit;

namespace HumanResources.Domain.Tests.Entities
{
    public class PersonnelDepartmentTests
    {
        private readonly PersonnelDepartment _personnelDepartment;

        public PersonnelDepartmentTests()
        {
            var deptSupervisor = new Employee(Role.ProjectManager, "Lewis", "Peter");
            _personnelDepartment = new PersonnelDepartment("Data Science Dept.", deptSupervisor);
        }

        [Fact]
        public void Constructor_WhenPassTitleSupervisor_InstanceHasValues()
        {
            var deptSupervisor = new Employee(Role.ProjectManager, "Lewis", "Peter");
            var newPersonnelDepartment = new PersonnelDepartment("Data Science Dept.", deptSupervisor);

            Assert.Equal("Data Science Dept.", newPersonnelDepartment.Title);
            Assert.Equal(Role.ProjectManager, deptSupervisor.Role);
        }

        [Fact]
        public void ChangeSupervisor_WhenPassRoleEqualsProjectManager_InstanceHasValues()
        {
            // arrange
            var deptSupervisor = new Employee(Role.ProjectManager, "Heinrich", "Claus");

            // act - dept.ChangeSupervisor()
            _personnelDepartment.ChangeSupervisor(deptSupervisor);

            // assert
            Assert.Equal(deptSupervisor,_personnelDepartment.DeptSupervisor);
        }

        [Fact]
        public void ChangeSupervisor_WhenPassRoleSupervisorDifferentFromProjectManager_ThrowsException()
        {
            var deptSupervisor = new Employee(Role.BusinessAnalyst, "Heinrich", "Claus");

            Assert.Throws<ArgumentException>(() => _personnelDepartment.ChangeSupervisor(deptSupervisor));
        }

        [Fact]
        public void UpdatePersonnelDepartmetInfo_WhenPassInfo_InstanceHasValues()
        {
            var deptSupervisor = new Employee(Role.ProjectManager, "Quinn", "James");
            var personnelDepartmentInfo = new PersonnelDepartmentInfo("Data Science Dept.", deptSupervisor);

            _personnelDepartment.UpdatePersonnelDepartmetInfo(personnelDepartmentInfo);

            Assert.Equal("Data Science Dept.", personnelDepartmentInfo.Title);
            Assert.Equal(Role.ProjectManager, personnelDepartmentInfo.DeptSupervisor.Role);
        }

        [Fact]
        public void UpdatePersonnelDepartmetInfo_NullInfo_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => _personnelDepartment.UpdatePersonnelDepartmetInfo(null));
        }

        [Fact]
        public void DeleteEmployee_WhenDeleteEmployee_IsEmployedIsFalse()
        {
            // arrange
            var emp = new Employee(Role.BusinessAnalyst, "Johnson", "Mike");
            _personnelDepartment.AddEmployee(emp);

            // act
            _personnelDepartment.DeleteEmployee(emp);

            // assert
            Assert.False(emp.IsEmployed);
        }

        [Fact]
        public void DeleteEmployee_WhenDepartmentDoesNotContainEmployee_ThrowsException()  
        {
            var emp = new Employee(Role.BusinessAnalyst, "Bond", "James");

            Assert.Throws<ArgumentException>(() => _personnelDepartment.DeleteEmployee(emp));
        }

        [Fact]
        public void DeleteEmployee_WhenDeleteAnUnemployedEmployee_ThrowsException()
        {
            // arrange
            var newEmp = new Employee(Role.BusinessAnalyst, "Johnson", "Mike");
            
            //assert
            Assert.Throws<ArgumentException>(() => _personnelDepartment.DeleteEmployee(newEmp));
        }

        [Fact]
        public void AddEmployee_WhenAddEmployee_DepartmentDoesNotContainEmployee() 
        {
            // arrange
            var emp = new Employee(Role.BusinessAnalyst, "Johnson", "Mike");
            _personnelDepartment.AddEmployee(emp);
            
            // act
            _personnelDepartment.DeleteEmployee(emp);

            //assert
            Assert.DoesNotContain(emp, _personnelDepartment.Employees);
        }

        [Fact]
        public void AddEmployee_WhenAddEmployee_DepartmentIncludesEmployee()
        {
            var emp = new Employee(Role.BusinessAnalyst, "Johnson", "Mike");

            _personnelDepartment.AddEmployee(emp);

            Assert.Contains(emp, _personnelDepartment.Employees);
        }

        [Fact]
        public void AddEmployee_WhenAddEmployee_IsEmployedIsTrue()
        {
            // arrange
            var emp = new Employee(Role.BusinessAnalyst, "Johnson", "Mike");

            // act
            _personnelDepartment.AddEmployee(emp);

            // assert
            Assert.True(emp.IsEmployed);
        }

        [Fact]
        public void AddEmployee_WhenWeAddAnEmployedEmployee_ThrowsException()
        {
            //arrange
            var emp = new Employee(Role.BusinessAnalyst, "Johnson", "Mike");
            _personnelDepartment.AddEmployee(emp);

            //assert
            Assert.Throws<ArgumentException>(() => _personnelDepartment.AddEmployee(emp));
        }

        [Fact]
        public void ReassignEmployeeTo_WhenTransferEmployeeToOtherDepartment_EmployeeBecomesPartOfOtherDepartment()
        {
            // arrange
            var emp = new Employee(Role.BusinessAnalyst, "Johnson", "Mike");
            _personnelDepartment.AddEmployee(emp);

            var deptSupervisor = new Employee(Role.ProjectManager, "Quinn", "James");
            var otherPersonnelDept = new PersonnelDepartment("Standardization Dept.", deptSupervisor);

            // act
            _personnelDepartment.ReassignEmployeeTo(emp, otherPersonnelDept);

            // assert
            Assert.Contains(emp, otherPersonnelDept.Employees);
        }

        
        [Fact]      
        public void ReassingEmployeeTo_WhenTransferEmployeeToOtherDepartment_EmployeeDoesNotExistInPreviousDept()
        {
            // arrange
            var emp = new Employee(Role.BusinessAnalyst, "Johnson", "Mike");
            _personnelDepartment.AddEmployee(emp);

            var deptSupervisor = new Employee(Role.ProjectManager, "Quinn", "James");
            var otherPersonnelDept = new PersonnelDepartment("Standardization Dept.", deptSupervisor);

            // act
            _personnelDepartment.ReassignEmployeeTo(emp, otherPersonnelDept);

            // assert
            Assert.DoesNotContain(emp, _personnelDepartment.Employees);
        }

        [Fact]
        public void ReassingEmployeeTo_WhenTransferEmployeeToOtherDepartment_IsEmployedIsTrue()
        {
            // arrange
            var emp = new Employee(Role.BusinessAnalyst, "Johnson", "Mike");
            _personnelDepartment.AddEmployee(emp);

            var deptSupervisor = new Employee(Role.ProjectManager, "Quinn", "James");
            var otherPersonnelDept = new PersonnelDepartment("Standardization Dept.", deptSupervisor);

            // act
            _personnelDepartment.ReassignEmployeeTo(emp, otherPersonnelDept);

            // assert
            Assert.True(emp.IsEmployed);
        }

        [Fact]
        public void ShowHierarchyPersonnelDepartment_WhenPassInfo_InstanceHasValues()
        {
            var hierarchyPersonnelDepartment =
                _personnelDepartment.ShowHierarchyPersonnelDepartment();

            Assert.Equal(_personnelDepartment.DeptSupervisor,hierarchyPersonnelDepartment["Department superviser: "][0]);
            Assert.Equal(_personnelDepartment.Employees, hierarchyPersonnelDepartment["Employees: "]);
        }
    }
}
