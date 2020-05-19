using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject.Models;
using CourseProject.Models.Users;

namespace CourseProject.ProjectFunctions
{
    public static class Authorization
    {
        public static User CheckAuthorization(string login, string password)
        {
            using (var user = new CourceProjectDbContext())
            {
                var users = new List<User>();
                users.AddRange(user.Administrators);
                users.AddRange(user.Accountants);
                users.AddRange(user.Owners);
                users.AddRange(user.Tenants);
                foreach (var item in users)
                {
                    if (item.Login == login && item.Password == password)
                    {
                        return item;
                    }
                }

                return null;
            }
        }
    }
}
