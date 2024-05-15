using System;
using System.Collections.Generic;

namespace EF1PJ1.Models
{
    public partial class District
    {
        public District()
        {
            Objects = new HashSet<Object>();
        }

        public int Districtcode { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Object> Objects { get; set; }
    }
}
