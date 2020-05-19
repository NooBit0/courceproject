using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject.ProjectFunctions;

namespace CourseProject.ViewModels
{
    public class FreePremisesPageGenerationViewModel
    {
        public static bool CheckNextPlaceId(int rentalPremisesId) => FreePremisesPageGeneration.CheckNextPlaceId(rentalPremisesId);

        public static void Save() => FreePremisesPageGeneration.Save();

        public static bool CheckPlaceOnNull() => FreePremisesPageGeneration.CheckPlaceOnNull();

        public static bool CheckBackPlaceId(int rentalPremisesId) => FreePremisesPageGeneration.CheckBackPlaceId(rentalPremisesId);

        public static string GetRentalPremises(int id) => FreePremisesPageGeneration.GetRentalPremises(id);

        public static int GetNextIdformDataBase(int rentalPremisesId) => FreePremisesPageGeneration.GetNextIdformDataBase(rentalPremisesId);

        public static int GetBackIdformDataBase(int rentalPremisesId) => FreePremisesPageGeneration.GetBackIdformDataBase(rentalPremisesId);

        public static bool CheckInputRentalEndDate(string rentalEndDate) => FreePremisesPageGeneration.CheckInputRentalEndDate(rentalEndDate);

        public static void AddToBasket(string login, int rentalPremisesId, string rentalBeginDate, string rentalEndDate) => FreePremisesPageGeneration.AddToBasket(login, rentalPremisesId, rentalBeginDate, rentalEndDate);

        public static int GetId() => FreePremisesPageGeneration.GetId();

        public static (string, string) GetImages(int id) => FreePremisesPageGeneration.GetImages(id);
    }
}
