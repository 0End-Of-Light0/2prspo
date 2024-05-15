using System;
using System.Collections.Generic;

namespace EF1PJ1.Models
{
    public partial class Type
    {
        public Type()
        {
            Objects = new HashSet<Object>();
        }

        public long Codetype { get; set; }
        public string? Nametype { get; set; }

        public virtual ICollection<Object> Objects { get; set; }
    }
}
