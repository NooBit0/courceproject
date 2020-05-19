using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject.ProjectFunctions;

namespace CourseProject.ViewModels
{
    public class BasketGenerationPageViewModel
    {
        public static string GetRentalPramses(string login) => BasketGenerationPage.GetRentalPramses(login);

        public static void AcceptRentalPramses() => BasketGenerationPage.AcceptRentalPramses();

        public static void СancelButton() => BasketGenerationPage.СancelButton();
    }
}
