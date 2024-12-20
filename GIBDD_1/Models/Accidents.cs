using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GIBDD_1.Models
{
    public partial class Accidents
    {
        public Accidents()
        {
            AccidentParticipants = new HashSet<AccidentParticipants>();
        }

        public int AccidentId { get; set; }
        public DateTime? DateTime { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int? OfficerId { get; set; }
        public int? RuleId { get; set; }

        public virtual Officers Officer { get; set; }
        public virtual TrafficRules Rule { get; set; }
        public virtual ICollection<AccidentParticipants> AccidentParticipants { get; set; }
    }
}
