using System;

namespace HumanResources.Domain
{
    public class ContactInfo
    {
        public string Email { get; protected set; }
        public string Cell { get; protected set; }
        public ContactInfo(string email, string cell)
        {
            if (email == null) throw new ArgumentNullException(nameof(email));
            if (cell == null) throw new ArgumentNullException(nameof(cell));

            Email = email;
            Cell = cell;
        }
    }
}