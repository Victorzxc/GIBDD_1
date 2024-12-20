using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GIBDD_1.Models
{
    public partial class Vehicles
    {
        public Vehicles()
        {
            AccidentParticipants = new HashSet<AccidentParticipants>();
            VehicleInspections = new HashSet<VehicleInspections>();
            Violations = new HashSet<Violations>();
        }

        public int VehicleId { get; set; }
        public string RegistrationNumber { get; set; }
        public string Vin { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public int? DriverId { get; set; }

        public virtual Drivers Driver { get; set; }
        public virtual ICollection<AccidentParticipants> AccidentParticipants { get; set; }
        public virtual ICollection<VehicleInspections> VehicleInspections { get; set; }
        public virtual ICollection<Violations> Violations { get; set; }
    }
}
