 using System;


namespace HumanResources.Domain.Entities
{
    public enum Role
    {
        Developer,
        Qa,
        ProjectManager,
        BusinessAnalyst,
        ProductOwner
    }

  
    public class Employee
    {
        public Employee(Role role, string surname, string name, string middleName = null)
        {
            Role = role;
            Surname = surname;
            Name = name;
            MiddleName = middleName;
            IsEmployed = false;
        }

    
        public int Id { get; protected set; }

        public string Surname { get; protected set; }
        public string Name { get; protected set; }
        public string MiddleName { get; protected set; }
        public string Email { get; protected set; }
        public string Cell { get; protected set; }
        public Role Role { get; protected set; }
        public bool IsEmployed { get; protected set; }

        public void UpdateContactInfo(ContactInfo contactInfo)
        {
            if (contactInfo == null) throw new ArgumentNullException(nameof(contactInfo), "Contact info can't be null");

            Cell = contactInfo.Cell;
            Email = contactInfo.Email;
        }

        public Employee MarkAsEmployed()
        {
            IsEmployed = true;
            return this;
        }

        public Employee MarkAsUnemployed()
        {
            IsEmployed = false;
            return this;
        }
    }
}