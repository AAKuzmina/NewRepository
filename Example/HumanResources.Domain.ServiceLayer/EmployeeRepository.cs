using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Employee = HumanResources.Domain.Entities.Employee;

namespace HumanResources.Domain.ServiceLayer
{
    public interface IEmployeeRepository : IDisposable
    {
        IEnumerable<Employee> GetEmployee();
        Employee GetEmployeeById(int employeeId);
        void AddEmployee(Employee employee);
        void DeleteEmployee(int employeeId);
        void UpdateEmployee(Employee employee);
        void Save();
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HumanResourcesDBEntities _context;

        public EmployeeRepository()
        {
            _context = new HumanResourcesDBEntities(); // new HumanResourcesContext();
        }

        public IEnumerable<Employee> GetEmployee()
        {
            return _context.Employee.ToList();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _context.Employee.Find(employeeId);
        }

        public void AddEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int employeeId)
        {
            var employee = GetEmployeeById(employeeId);
            if (employee != null)
                _context.Employee.Remove(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
