using System;
using System.Collections.Generic;

namespace EF1PJ1.Models
{
    public partial class Object
    {
        public Object()
        {
            Evaluations = new HashSet<Evaluation>();
            Sales = new HashSet<Sale>();
        }

        public int Objcode { get; set; }
        public int? District { get; set; }
        public string? Adress { get; set; }
        public int? Floor { get; set; }
        public int? Cellcount { get; set; }
        public long? Type { get; set; }
        public int? State { get; set; }
        public double? Cost { get; set; }
        public string? Message { get; set; }
        public int? Material { get; set; }
        public double? Square { get; set; }
        public DateOnly? Date { get; set; }

        public virtual District? DistrictNavigation { get; set; }
        public virtual Buildingmaterial? MaterialNavigation { get; set; }
        public virtual Type? TypeNavigation { get; set; }
        public virtual ICollection<Evaluation> Evaluations { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
