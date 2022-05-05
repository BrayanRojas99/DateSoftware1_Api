using System;
using System.Collections.Generic;

#nullable disable

namespace DateSoftware1_Api.Models
{
    public partial class User
    {
        public User()
        {
            Dates = new HashSet<Date>();
            GeneralInformations = new HashSet<GeneralInformation>();
        }

        public int UserId { get; set; }
        public string Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string RecuperationCode { get; set; }
        public string Password { get; set; }
        public bool? Status { get; set; }
        public int UserRoleId { get; set; }

        public virtual UserRol UserRole { get; set; }
        public virtual ICollection<Date> Dates { get; set; }
        public virtual ICollection<GeneralInformation> GeneralInformations { get; set; }
    }
}
