using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Domain.ServiceLayer
{
    public partial class Employee
    {
        public void UpdateContactInfo(ContactInfo contactInfo)
        {
            if (contactInfo == null) throw new ArgumentNullException(nameof(contactInfo), "Contact info can't be null");

            Cell = contactInfo.Cell;
            Email = contactInfo.Email;
        }

        public Employee MarkAsEmployed()
        {
            //IsEmployed = true;
            return this;
        }

        public Employee MarkAsUnemployed()
        {
            //IsEmployed = false;
            return this;
        }
    }
}
