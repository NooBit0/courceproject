using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject.Models;

namespace CourseProject.ProjectFunctions
{
    public class ArendetPremisesPageGeneration
    {
        public static bool CheckNextPlaceId(string login, int tenantRentalPremisesId)
        {
            using var users = new CourceProjectDbContext();
            int tenantId = users.Tenants.Where(a => a.Login == login).Select(a => a.TenantId).FirstOrDefault();
            int temp = users.Tenants.Where(a => a.TenantId == tenantId && a.RentalPremises.RentalPremisesId > tenantRentalPremisesId).Select(a => a.RentalPremises.RentalPremisesId).Count();
            if (temp != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckPlaceOnNull(string login)
        {
            using var users = new CourceProjectDbContext();
            int tenantId = users.Tenants.Where(a => a.Login == login).Select(a => a.TenantId).FirstOrDefault();
            int temp = users.Tenants.Select(a => a.RentalPremises).Count();
            if (temp == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool CheckBackPlaceId(string login, int tenantRentalPremisesId)
        {
            using var users = new CourceProjectDbContext();
            int tenantId = users.Tenants.Where(a => a.Login == login).Select(a => a.TenantId).FirstOrDefault();
            int temp = users.Tenants.Where(a => a.TenantId == tenantId && a.RentalPremises.RentalPremisesId < tenantRentalPremisesId).Select(a => a.RentalPremises.RentalPremisesId).Count();
            if (temp != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckRentalStatus(string login, int rentalPremisesId)
        {
            var buildingsItems = new CourceProjectDbContext();
            var users = new CourceProjectDbContext();
            int temp = users.Tenants.Where(a => a.Login == login).Where(a => a.RentalPremises.RentalPremisesId == rentalPremisesId).Select(a => a.RentalPremises.RentalPremisesId).First();
            return buildingsItems.RentalPremises.Where(a => a.RentalPremisesId == temp).First().RentalCheck;
        }

        public static string GetRentalPremises(int rentalPremisesId)
        {
            using (var bildings = new CourceProjectDbContext())
            {
                RentalPremises rentalPremises = bildings?.RentalPremises.Where(b => b.RentalPremisesId == rentalPremisesId).FirstOrDefault();
                string adress = bildings?.RentalPremises.Where(b => b.RentalPremisesId == rentalPremisesId).Select(a => a.Building.Adress).FirstOrDefault().ToString();

                return $"{adress} \n\n {rentalPremises.Price.ToString()} \n\n {rentalPremises.Area.ToString()} \n\n" +
                $"{rentalPremises.RentalBeginDate.ToString()} \n\n {rentalPremises.RentalEndDate.ToString()} \n\n" +
                $"{rentalPremises.RentalNumber.ToString()}";
            }
        }

        public static (string, string) GetImages(int rentalPremisesId)
        {
            var bildings = new CourceProjectDbContext();
            string rentalPremisesImage = bildings.RentalPremises.Where(a => a.RentalPremisesId == rentalPremisesId).Select(a => a.Image).FirstOrDefault();
            string bildingPremisesImage = bildings.RentalPremises.Where(a => a.RentalPremisesId == rentalPremisesId).Select(a => a.Building.Image).FirstOrDefault();
            return (rentalPremisesImage, bildingPremisesImage);
        }

        public static int GetNextTenentPremisesIdformDataBase(string login, int tenantRentalPremisesId)
        {
            using var users = new CourceProjectDbContext();
            int tenantId = users.Tenants.Where(a => a.Login == login).Select(a => a.TenantId).FirstOrDefault();
            return users.Tenants.Where(a => a.TenantId == tenantId && a.RentalPremises.RentalPremisesId > tenantRentalPremisesId).Select(a => a.RentalPremises.RentalPremisesId).FirstOrDefault();
        }

        public static int GetBackTenentPremisesIdformDataBase(string login, int tenantRentalPremisesId)
        {
            using var users = new CourceProjectDbContext();
            int tenantId = users.Tenants.Where(a => a.Login == login).Select(a => a.TenantId).FirstOrDefault();
            return users.Tenants.Where(a => a.TenantId == tenantId && a.RentalPremises.RentalPremisesId < tenantRentalPremisesId).Select(a => a.RentalPremises.RentalPremisesId).ToList().LastOrDefault();
        }

        public static int GetNextIdformDataBase(string login, int tenantRentalPremisesId)
        {
            using var users = new CourceProjectDbContext();
            int tenantId = users.Tenants.Where(a => a.Login == login).Select(a => a.TenantId).FirstOrDefault();
            return users.Tenants.Where(a => a.TenantId == tenantId && a.RentalPremises.RentalPremisesId > tenantRentalPremisesId).Select(a => a.RentalPremises.RentalPremisesId).FirstOrDefault();
        }

        public static int GetBackIdformDataBase(string login, int tenantRentalPremisesId)
        {
            using var users = new CourceProjectDbContext();
            int tenantId = users.Tenants.Where(a => a.Login == login).Select(a => a.TenantId).FirstOrDefault();
            return users.Tenants.Where(a => a.TenantId == tenantId && a.RentalPremises.RentalPremisesId < tenantRentalPremisesId).Select(a => a.RentalPremises.RentalPremisesId).ToList().LastOrDefault();
        }

        public static int GetFirstTenantRentalPremisesId(string login)
        {
            using var users = new CourceProjectDbContext();
            return users.Tenants.Where(a => a.Login == login).Select(a => a.RentalPremises.RentalPremisesId).FirstOrDefault();
        }

        public static int GetFirstId(string login)
        {
            using var users = new CourceProjectDbContext();
            return users.Tenants.Where(a => a.Login == login).Select(a => a.RentalPremises.RentalPremisesId).First();
        }
    }
}
