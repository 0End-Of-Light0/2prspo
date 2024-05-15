using System;
using System.Collections.Generic;

namespace EF1PJ1.Models
{
    public partial class EvaluationCr
    {
        public EvaluationCr()
        {
            Evaluations = new HashSet<Evaluation>();
        }

        public int CrCode { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Evaluation> Evaluations { get; set; }
    }
}
