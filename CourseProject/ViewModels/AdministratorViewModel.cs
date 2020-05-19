using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Text;
using CourseProject.Models;
using CourseProject.Models.Users;
using CourseProject.ProjectFunctions;

namespace CourseProject.ViewModels
{
    public class AdministratorViewModel
    {
        public AdministratorViewModel()
        {
            DataBase = new DataBase();
        }

        public DataBase DataBase { get; set; }

        public ObservableCollection<Accountant> GetAccountants() => DataBase.GetAccountants();

        public ObservableCollection<Administrator> GetAdministrators() => DataBase.GetAdministrators();

        public ObservableCollection<Owner> GetOwners() => DataBase.GetOwners();

        public ObservableCollection<Tenant> GetTenants() => DataBase.GetTenants();

        public ObservableCollection<Building> GetBildings() => DataBase.GetBildings();

        public ObservableCollection<RentalPremises> GetRentalPremises() => DataBase.GetRentalPremises();

        public void UsersDbSave() => DataBase.UsersDbSave();

        public void CourseProjectDbSave() => DataBase.CourseProjectDbSave();
    }
}
