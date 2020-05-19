using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CourseProject.Models;

namespace CourseProject.ProjectFunctions
{
    public static class FreePremisesPageGeneration
    {
        public static void Save()
        {
            using var users = new CourceProjectDbContext();
            users.SaveChanges();
        }

        public static void AddToBasket(string login, int rentalPremisesId, string rentalBeginDate, string rentalEndDate)
        {
            using (var userItems = new CourceProjectDbContext())
            {
                var chengeRentalPremises = userItems.Tenants.Where(a => a.Login == login).Select(a => a.RentalPremises.Where(a => a.RentalPremisesId == rentalPremisesId)).FirstOrDefault().FirstOrDefault();
                chengeRentalPremises.RentalBeginDate = rentalBeginDate;
                chengeRentalPremises.RentalEndDate = rentalEndDate;

                userItems.SaveChanges();
            }
        }

        public static bool CheckNextPlaceId(int rentalPremisesId)
        {
            var bildings = new CourceProjectDbContext();
            int temp = bildings.RentalPremises.Where(a => a.RentalPremisesId > rentalPremisesId && a.RentalCheck == false && a.RentalBeginDate == null).Count();
            if (temp != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckPlaceOnNull()
        {
            var bildings = new CourceProjectDbContext();
            int temp = bildings.RentalPremises.Count();
            if (temp == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool CheckBackPlaceId(int rentalPremisesId)
        {
            var bildings = new CourceProjectDbContext();
            int temp = bildings.RentalPremises.Where(a => a.RentalPremisesId < rentalPremisesId && a.RentalCheck == false && a.RentalBeginDate == null).Count();
            if (temp != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetRentalPremises(int id)
        {
            using (var bildings = new CourceProjectDbContext())
            {
                RentalPremises rentalPremises = bildings?.RentalPremises.Where(b => b.RentalPremisesId == id).FirstOrDefault();
                string adress = bildings?.RentalPremises.Where(b => b.RentalPremisesId == id).Select(a => a.Building.Adress).FirstOrDefault().ToString();

                return $"{adress} \n\n {rentalPremises.Price.ToString()} \n\n {rentalPremises.Area.ToString()} \n\n" +
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

        public static int GetNextIdformDataBase(int rentalPremisesId)
        {
            using var bildings = new CourceProjectDbContext();
            return bildings.RentalPremises.Where(a => a.RentalPremisesId > rentalPremisesId && a.RentalCheck == false && a.RentalBeginDate == null).Select(a => a.RentalPremisesId).First();
        }

        public static int GetBackIdformDataBase(int rentalPremisesId)
        {
            using var bildings = new CourceProjectDbContext();
            return bildings.RentalPremises.Where(a => a.RentalPremisesId < rentalPremisesId && a.RentalCheck == false && a.RentalBeginDate == null && a.RentalPremisesId != 0).ToList().Last().RentalPremisesId;
        }

        public static bool CheckInputRentalEndDate(string rentalEndDate)
        {
            if (Regex.IsMatch(rentalEndDate, @"^((0[1-9]|[12]\d|3[01])\/(0[1-9]|1[0-2])\/(2020|202[0-4]))$"))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static int GetId()
        {
            using var bildings = new CourceProjectDbContext();
            return bildings.RentalPremises.Where(a => a.RentalCheck == false && a.RentalBeginDate == null).FirstOrDefault().RentalPremisesId;
        }
    }
}
