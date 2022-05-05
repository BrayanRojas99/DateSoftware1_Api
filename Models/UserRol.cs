using System;
using System.Collections.Generic;

#nullable disable

namespace DateSoftware1_Api.Models
{
    public partial class UserRol
    {
        public UserRol()
        {
            Users = new HashSet<User>();
        }

        public int UserRoleId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
