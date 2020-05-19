using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject.Models.Users
{
    public class User
    {
        public string FullName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public override string ToString()
        {
            return $"Full Name: {FullName} \n" +
                $"Login: {Login}";
        }
    }
}
