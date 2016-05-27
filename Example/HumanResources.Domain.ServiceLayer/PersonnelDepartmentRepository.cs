using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PersonnelDepartment = HumanResources.Domain.Entities.PersonnelDepartment;

namespace HumanResources.Domain.ServiceLayer
{

    public interface IPersonnelDepartmentRepository : IDisposable
    {
        IEnumerable<PersonnelDepartment> GetPersonnelDepartments();
        PersonnelDepartment GetPersonnelDepartmentById(int personnelDepartmentId);
        void AddPersonnelDepartmen(PersonnelDepartment personnelDepartment);
        void DeletePersonnelDepartment(int personnelDepartmentId);
        void UpdatePersonnelDepartment(PersonnelDepartment personnelDepartment);
        void Save();
    }

    public class PersonnelDepartmentRepository : IPersonnelDepartmentRepository
    {
        private readonly HumanResourcesContext _context;

        public PersonnelDepartmentRepository()
        {
            _context = new HumanResourcesContext();
        }

        public IEnumerable<PersonnelDepartment> GetPersonnelDepartments()
        {
            return _context.PersonnelDepartments.ToList();
        }

        public PersonnelDepartment GetPersonnelDepartmentById(int personnelDepartmentId)
        {
            return _context.PersonnelDepartments.Find(personnelDepartmentId);
        }

        public void AddPersonnelDepartmen(PersonnelDepartment personnelDepartment)
        {
            _context.PersonnelDepartments.Add(personnelDepartment);
        }

        public void DeletePersonnelDepartment(int personnelDepartmentId)
        {
            var personnelDepartment = GetPersonnelDepartmentById(personnelDepartmentId);
            if (personnelDepartment != null)
            {
                _context.PersonnelDepartments.Remove(personnelDepartment);
            }
        }

        public void UpdatePersonnelDepartment(PersonnelDepartment personnelDepartment)
        {
            _context.Entry(personnelDepartment).State = EntityState.Modified;
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
  

