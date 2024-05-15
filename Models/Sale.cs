using System;
using System.Collections.Generic;

namespace EF1PJ1.Models
{
    public partial class Sale
    {
        public int SaleCode { get; set; }
        public int? ObjCode { get; set; }
        public DateOnly? Date { get; set; }
        public int? CodeRe { get; set; }
        public double Price { get; set; }

        public virtual Realtor? CodeReNavigation { get; set; }
        public virtual Object? ObjCodeNavigation { get; set; }
    }
}
