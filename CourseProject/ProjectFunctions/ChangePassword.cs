using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject.Models;
using CourseProject.Models.Users;

namespace CourseProject.ProjectFunctions
{
    public class ChangePassword
    {
        public static void Change(string login, string password)
        {
            using (var users = new CourceProjectDbContext())
            {
                var tenant = users.Tenants.Where(a => a.Login == login).FirstOrDefault();
                tenant.Password = password;

                users.SaveChanges();
            }
        }

        public static bool CheckOldPassword(string login, string password)
        {
            using (var users = new CourceProjectDbContext())
            {
                var tenant = users.Tenants.Where(a => a.Login == login && a.Password == password).FirstOrDefault();
                if (tenant != null)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
