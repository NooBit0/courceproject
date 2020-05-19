using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject.Models.Users;
using CourseProject.ProjectFunctions;

namespace CourseProject.ViewModels
{
    public class AuthorizationViewModel
    {
        public static bool CheckLogin(string login) => Registration.CheckLogin(login);

        public static User CheckAuthorization(string login, string password) => Authorization.CheckAuthorization(login, password);

        public static void RegistrationUser(string fullName, string login, string password) => Registration.RegistrationUser(fullName, login, password);
    }
}
