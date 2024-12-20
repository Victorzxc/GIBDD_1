using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GIBDD_1.Models
{
    public partial class TrafficRules
    {
        public TrafficRules()
        {
            Accidents = new HashSet<Accidents>();
        }

        public int RuleId { get; set; }
        public string ArticleNumber { get; set; }
        public string Description { get; set; }
        public decimal? BaseFine { get; set; }
        public decimal? CoefficientMultiplier { get; set; }

        public virtual ICollection<Accidents> Accidents { get; set; }
    }
}
