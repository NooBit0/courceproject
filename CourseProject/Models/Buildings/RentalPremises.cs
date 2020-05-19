using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CourseProject.Models.Users;

namespace CourseProject.Models
{
    public class RentalPremises
    {
        public Building Building { get; set; }

        public Tenant Tenant { get; set; }

        public string Image { get; set; }

        public int RentalNumber { get; set; }

        public int RentalPremisesId { get; set; }

        public bool RentalCheck { get; set; }

        public float Price { get; set; }

        public int BuildingId { get; set; }

        public float Area { get; set; }

        public string RentalBeginDate { get; set; }

        public string RentalEndDate { get; set; }

        public override string ToString()
        {
            return $"\nArea: {Area}\nPrice: {Price}\nRentalNumber: {RentalNumber}\nRentalBeginDate: {RentalBeginDate}\nRentalEndDate: {RentalEndDate}\n";
        }
    }
}
