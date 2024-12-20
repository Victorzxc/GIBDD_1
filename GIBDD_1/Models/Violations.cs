using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GIBDD_1.Models
{
    public partial class Violations
    {
        public int ViolationId { get; set; }
        public int? DriverId { get; set; }
        public int? VehicleId { get; set; }
        public string ViolationCode { get; set; }
        public int? ViolationTypeId { get; set; }
        public string Location { get; set; }
        public decimal? FineAmount { get; set; }
        public int? OfficerId { get; set; }
        public string PaymentStatus { get; set; }

        public virtual Drivers Driver { get; set; }
        public virtual Officers Officer { get; set; }
        public virtual Vehicles Vehicle { get; set; }
        public virtual ViolationTypes ViolationType { get; set; }
    }
}
