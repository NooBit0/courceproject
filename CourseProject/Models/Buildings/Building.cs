using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CourseProject.Models
{
    public class Building
    {
        public ICollection<RentalPremises> RentalPremises { get; set; }

        public string Adress { get; set; }

        public string Image { get; set; }

        public int BuildingId { get; set; }
    }
}
