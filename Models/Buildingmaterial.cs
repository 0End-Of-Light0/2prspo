using System;
using System.Collections.Generic;

namespace EF1PJ1.Models
{
    public partial class Buildingmaterial
    {
        public Buildingmaterial()
        {
            Objects = new HashSet<Object>();
        }

        public int Materialcode { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Object> Objects { get; set; }
    }
}
