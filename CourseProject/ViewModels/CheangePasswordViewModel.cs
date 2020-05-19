using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject.ProjectFunctions;

namespace CourseProject.ViewModels
{
    public class CheangePasswordViewModel
    {
        public static void Change(string login, string password) => ChangePassword.Change(login, password);

        public static bool CheckOldPassword(string login, string password) => ChangePassword.CheckOldPassword(login, password);
    }
}
