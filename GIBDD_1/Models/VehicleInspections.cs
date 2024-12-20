using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GIBDD_1.Models
{
    public partial class VehicleInspections
    {
        public int InspectionId { get; set; }
        public int? VehicleId { get; set; }
        public DateTime? InspectionDate { get; set; }
        public string Result { get; set; }

        public virtual Vehicles Vehicle { get; set; }
    }
}
