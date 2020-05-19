using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject.ProjectFunctions;

namespace CourseProject.ViewModels
{
    public class UserViewModel
    {
        public static string GetInfoForUser(string login) => ReceivingInformation.GetInfoForUser(login);
    }
}
