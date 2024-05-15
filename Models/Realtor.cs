using System;
using System.Collections.Generic;

namespace EF1PJ1.Models
{
    public partial class Realtor
    {
        public Realtor()
        {
            Sales = new HashSet<Sale>();
        }

        public int ReCode { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Patronymic { get; set; }
        public string? Telephone { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
