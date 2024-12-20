using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GIBDD_1.Models
{
    public partial class ViolationTypes
    {
        public ViolationTypes()
        {
            Violations = new HashSet<Violations>();
        }

        public int ViolationTypeId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal? FineBase { get; set; }

        public virtual ICollection<Violations> Violations { get; set; }
    }
}
