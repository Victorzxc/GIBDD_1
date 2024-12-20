using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GIBDD_1.Models
{
    public partial class Officers
    {
        public Officers()
        {
            Accidents = new HashSet<Accidents>();
            Violations = new HashSet<Violations>();
        }

        public int OfficerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string OfficerNumber { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Accidents> Accidents { get; set; }
        public virtual ICollection<Violations> Violations { get; set; }
    }
}
