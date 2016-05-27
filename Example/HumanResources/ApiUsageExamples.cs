using HumanResources.Domain.Entities;

namespace HumanResources.Domain
{
    public class ApiUsageExamples
    {
        private void Foo()
        {
            var peterLewis = new Employee(Role.ProjectManager, "Lewis", "Peter");
            var jamesBond = new Employee(Role.Developer, "Bond", "James");
            var jamesQuinn = new Employee(Role.BusinessAnalyst, "Quinn", "James");  
            var heinrichClaus = new Employee(Role.Qa, "Claus", "Heinrich");

            var annaHoltzman = new Employee(Role.ProjectManager, "Holtzman","Anna");
            var gregoryDevids = new Employee(Role.Qa,"Davids","Gregory");
            var matJones = new Employee(Role.BusinessAnalyst,"Jones","Mat");
            var johnDoe = new Employee(Role.Developer, "Doe", "John");

            var dep1 = new PersonnelDepartment("Data Science Dept.",  jamesQuinn);
            var dep2 = new PersonnelDepartment("Standardization Dept.", annaHoltzman);
            var dep3 = new PersonnelDepartment("Planning Dept.", peterLewis);

            jamesBond.UpdateContactInfo(new ContactInfo("a@a.com", "+7112123456"));
            heinrichClaus.UpdateContactInfo(new ContactInfo("m@mail.ru","+79543848586"));

            dep1.AddEmployee(jamesBond);
            dep1.AddEmployee(jamesQuinn);
            dep1.AddEmployee(heinrichClaus);

            dep2.AddEmployee(gregoryDevids);
            dep2.AddEmployee(matJones);
            dep2.AddEmployee(johnDoe);

            dep1.ReassignEmployeeTo(jamesQuinn, dep2);
            dep2.ReassignEmployeeTo(johnDoe,dep1);

            dep2.UpdatePersonnelDepartmetInfo(new PersonnelDepartmentInfo("Financial Dep.", peterLewis));

            dep1.DeleteEmployee(gregoryDevids);

        }
    }
}