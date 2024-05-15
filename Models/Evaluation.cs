using System;
using System.Collections.Generic;

namespace EF1PJ1.Models
{
    public partial class Evaluation
    {
        public int EvCode { get; set; }
        public int? ObjCode { get; set; }
        public DateOnly? Date { get; set; }
        public int? CrCode { get; set; }
        public int? Evulation { get; set; }

        public virtual EvaluationCr? CrCodeNavigation { get; set; }
        public virtual Object? ObjCodeNavigation { get; set; }
    }
}
