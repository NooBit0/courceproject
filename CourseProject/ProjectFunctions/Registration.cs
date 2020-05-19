using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject.Models;
using CourseProject.Models.Users;

namespace CourseProject.ProjectFunctions
{
    public class Registration
    {
        public static bool CheckLogin(string login)
        {
            using (var usersDb = new CourceProjectDbContext())
            {
                var users = new List<User>();
                users.AddRange(usersDb.Administrators);
                users.AddRange(usersDb.Accountants);
                users.AddRange(usersDb.Owners);
                users.AddRange(usersDb.Tenants);

                foreach (var item in users)
                {
                    if (item.Login == login)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static void RegistrationUser(string fullName, string login, string password)
        {
            var usersDb = new CourceProjectDbContext();
            usersDb.Tenants.Add(new Tenant(fullName, login, password));
            usersDb.SaveChanges();
        }
    }
}
