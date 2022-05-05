using System;
using System.Collections.Generic;

#nullable disable

namespace DateSoftware1_Api.Models
{
    public partial class Ailment
    {
        public Ailment()
        {
            DetailAilments = new HashSet<DetailAilment>();
        }

        public int IdAilment { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DetailAilment> DetailAilments { get; set; }
    }
}
