using System;
using System.Collections.Generic;

#nullable disable

namespace DateSoftware1_Api.Models
{
    public partial class DetailExtraValue
    {
        public int IdDetailExtraValue { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal FinalPrice { get; set; }
        public int IdExtraValue { get; set; }
        public int IdDate { get; set; }

        public virtual Date IdDateNavigation { get; set; }
        public virtual ExtraValue IdExtraValueNavigation { get; set; }
    }
}
