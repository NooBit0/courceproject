using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject.ProjectFunctions;

namespace CourseProject.ViewModels
{
    public class ArendetPremisesPageGenerationViewModel
    {
        public static bool CheckRentalStatus(string login, int rentalPremisesId) => ArendetPremisesPageGeneration.CheckRentalStatus(login, rentalPremisesId);

        public static bool CheckNextPlaceId(string login, int tenantRentalPremisesId) => ArendetPremisesPageGeneration.CheckNextPlaceId(login, tenantRentalPremisesId);

        public static bool CheckBackPlaceId(string login, int tenantRentalPremisesId) => ArendetPremisesPageGeneration.CheckBackPlaceId(login, tenantRentalPremisesId);

        public static bool CheckPlaceOnNull(string login) => ArendetPremisesPageGeneration.CheckPlaceOnNull(login);

        public static int GetFirstId(string login) => ArendetPremisesPageGeneration.GetFirstId(login);

        public static string GetRentalPremises(int id) => ArendetPremisesPageGeneration.GetRentalPremises(id);

        public static (string, string) GetImages(int rentalPremisesId) => ArendetPremisesPageGeneration.GetImages(rentalPremisesId);

        public static int GetFirstTenantRentalPremisesId(string login) => ArendetPremisesPageGeneration.GetFirstTenantRentalPremisesId(login);

        public static int GetNextIdformDataBase(string login, int tenantRentalPremisesId) => ArendetPremisesPageGeneration.GetNextIdformDataBase(login, tenantRentalPremisesId);

        public static int GetNextTenentPremisesIdformDataBase(string login, int tenantRentalPremisesId) => ArendetPremisesPageGeneration.GetNextTenentPremisesIdformDataBase(login, tenantRentalPremisesId);

        public static int GetBackIdformDataBase(string login, int tenantRentalPremisesId) => ArendetPremisesPageGeneration.GetBackIdformDataBase(login, tenantRentalPremisesId);

        public static int GetBackTenentPremisesIdformDataBase(string login, int tenantRentalPremisesId) => ArendetPremisesPageGeneration.GetBackTenentPremisesIdformDataBase(login, tenantRentalPremisesId);
    }
}
