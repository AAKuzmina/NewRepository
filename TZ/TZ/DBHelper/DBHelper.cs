using System.Collections.Generic;
using System.Linq;

namespace DBHelper
{
    public class DBHelper
    {
        public static void AddEmployee(string surname,string name,string middleName,string role,string email, long phone, int chiefId, string division)
        {
            using (var context =new DataEmployeeDataContext() )
            {
                Employee newEmployee = new Employee
                {
                    Surname = surname,
                    Name = name,
                    MiddleName = middleName,
                    Role =role,
                    Email = email,
                    Phone =phone,
                    ChiefId = chiefId,
                    Division =division
                };
                context.GetTable<Employee>().InsertOnSubmit(newEmployee);
                context.SubmitChanges();
            }
           
        }

        public static List<Employee> GetEmployees()
        {
            List<Employee> employeesList;
            using (var context = new DataEmployeeDataContext())
            {
                employeesList = (from u in context.Employee select u).ToList();
            }
            return employeesList;
        }

        public static string[] GetIdAndFIO(List<Employee> employeesList)
        {
            var chiefsList = new string[employeesList.Count];
            for (int i = 0; i < employeesList.Count; i++)
            {
                chiefsList[i]=employeesList[i].Id + ". " + employeesList[i].Surname + " " + employeesList[i].Name + " " + employeesList[i].MiddleName;
            }
            return chiefsList;
        }

        public static void UpdateEmployee(int employeeId, int newEmployeeId)
        {
            using (var context = new DataEmployeeDataContext())
            {
                var employee = (from u in context.Employee where u.ChiefId == employeeId select u).SingleOrDefault();
                employee.ChiefId = newEmployeeId;
                context.SubmitChanges();
            }
        }
        public static string GetChief(int id)
        {
            string chief;
            using (var context = new DataEmployeeDataContext())
            {
                chief = (from u in context.Employee where u.Id == id select u.Surname+" "+u.Name+" "+u.MiddleName).SingleOrDefault();
            }
            return chief;
        }
    }
}
