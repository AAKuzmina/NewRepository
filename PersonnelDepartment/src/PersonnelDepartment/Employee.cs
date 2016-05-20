using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonnelDepartment
{
    public class Employee
    {
        //один человек относится только к 1 разделу.
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int ChiefId { get; set; }//переименовать по-другому
        public PersonnelDepartment PersonnelDepartment { get; set; }
    }
}
