using System;
using System.Collections.Generic;

#nullable disable

namespace DateSoftware1_Api.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Dates = new HashSet<Date>();
        }

        public int IdDoctor { get; set; }
        public string Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public bool? Status { get; set; }
        public int IdSpecialityDoctor { get; set; }

        public virtual SpecialityDoctor IdSpecialityDoctorNavigation { get; set; }
        public virtual ICollection<Date> Dates { get; set; }
    }
}
