using System;
using HumanResources.Domain.Entities;

namespace HumanResources.Domain 
{

    public class PersonnelDepartmentInfo
    {
       
        public string Title { get; protected set; }
        public Employee DeptSupervisor { get; protected set; }

        public PersonnelDepartmentInfo(string title, Employee deptSupervisor)
        {
            if (title == null) throw new ArgumentNullException(nameof(title));
            if (deptSupervisor == null) throw new ArgumentNullException(nameof(deptSupervisor));

            Title = title;
            DeptSupervisor = deptSupervisor;
        }
    }
}
