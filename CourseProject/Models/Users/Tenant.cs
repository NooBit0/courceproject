using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject.Models.Users
{
    public class Tenant : User
    {
        public Tenant()
        {
        }

        public Tenant(string fullName, string login, string password)
        {
            FullName = fullName;
            Login = login;
            Password = password;
        }

        public int TenantId { get; set; }

        public ICollection<RentalPremises> RentalPremises { get; set; }
    }
}
