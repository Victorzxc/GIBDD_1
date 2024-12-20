using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GIBDD_1.Models
{
    public partial class Drivers
    {
        public Drivers()
        {
            AccidentParticipants = new HashSet<AccidentParticipants>();
            MedicalCertificates = new HashSet<MedicalCertificates>();
            Vehicles = new HashSet<Vehicles>();
            Violations = new HashSet<Violations>();
        }

        public int DriverId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string DriverLicenseNumber { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<AccidentParticipants> AccidentParticipants { get; set; }
        public virtual ICollection<MedicalCertificates> MedicalCertificates { get; set; }
        public virtual ICollection<Vehicles> Vehicles { get; set; }
        public virtual ICollection<Violations> Violations { get; set; }
    }
}
