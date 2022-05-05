using System;
using System.Collections.Generic;

#nullable disable

namespace DateSoftware1_Api.Models
{
    public partial class TypeDate
    {
        public TypeDate()
        {
            Dates = new HashSet<Date>();
        }

        public int IdTypeDate { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }

        public virtual ICollection<Date> Dates { get; set; }
    }
}
