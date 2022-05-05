using System;
using System.Collections.Generic;

#nullable disable

namespace DateSoftware1_Api.Models
{
    public partial class SpecialityDoctor
    {
        public SpecialityDoctor()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int IdSpecialityDoctor { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
