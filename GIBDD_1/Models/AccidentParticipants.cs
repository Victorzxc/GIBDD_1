using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GIBDD_1.Models
{
    public partial class AccidentParticipants
    {
        public int ParticipantId { get; set; }
        public int? AccidentId { get; set; }
        public int? DriverId { get; set; }
        public int? VehicleId { get; set; }
        public string Role { get; set; }

        public virtual Accidents Accident { get; set; }
        public virtual Drivers Driver { get; set; }
        public virtual Vehicles Vehicle { get; set; }
    }
}
