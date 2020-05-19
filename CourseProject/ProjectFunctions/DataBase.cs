using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject.Models;
using CourseProject.Models.Users;

namespace CourseProject.ProjectFunctions
{
    public class DataBase
    {
        public DataBase()
        {
            UserDataBase = new CourceProjectDbContext();
            CoursesProjectDataBase = new CourceProjectDbContext();
            CoursesProjectDataBase.Buildings.Load();
            CoursesProjectDataBase.RentalPremises.Load();
            UserDataBase.Accountants.Load();
            UserDataBase.Administrators.Load();
            UserDataBase.Owners.Load();
            UserDataBase.Tenants.Load();
        }

        public CourceProjectDbContext UserDataBase { get; set; }

        public CourceProjectDbContext CoursesProjectDataBase { get; set; }

        public ObservableCollection<Accountant> GetAccountants() => UserDataBase.Accountants.Local;

        public ObservableCollection<Administrator> GetAdministrators() => UserDataBase.Administrators.Local;

        public ObservableCollection<Owner> GetOwners() => UserDataBase.Owners.Local;

        public ObservableCollection<Tenant> GetTenants() => UserDataBase.Tenants.Local;

        public ObservableCollection<Building> GetBildings() => CoursesProjectDataBase.Buildings.Local;

        public ObservableCollection<RentalPremises> GetRentalPremises() => CoursesProjectDataBase.RentalPremises.Local;

        public void UsersDbSave() => UserDataBase.SaveChanges();

        public void CourseProjectDbSave() => CoursesProjectDataBase.SaveChanges();
    }
}
