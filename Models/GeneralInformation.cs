using System;
using System.Collections.Generic;

#nullable disable

namespace DateSoftware1_Api.Models
{
    public partial class GeneralInformation
    {
        public GeneralInformation()
        {
            DetailAilments = new HashSet<DetailAilment>();
        }

        public int IdInformation { get; set; }
        public string TypeBlood { get; set; }
        public string Gender { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public int Age { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<DetailAilment> DetailAilments { get; set; }
    }
}
