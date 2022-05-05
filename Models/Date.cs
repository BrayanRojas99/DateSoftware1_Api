using System;
using System.Collections.Generic;

#nullable disable

namespace DateSoftware1_Api.Models
{
    public partial class Date
    {
        public Date()
        {
            DetailExtraValues = new HashSet<DetailExtraValue>();
        }

        public int IdDate { get; set; }
        public DateTime Date1 { get; set; }
        public decimal InitialCost { get; set; }
        public bool? Estado { get; set; }
        public decimal? FinalCost { get; set; }
        public int IdDoctor { get; set; }
        public int UserId { get; set; }
        public int IdTypeDate { get; set; }

        public virtual Doctor IdDoctorNavigation { get; set; }
        public virtual TypeDate IdTypeDateNavigation { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<DetailExtraValue> DetailExtraValues { get; set; }
    }
}
