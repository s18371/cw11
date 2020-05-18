using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;

namespace cw11.Models
{
    public class Prescription_Medicament
    {
        public int IdPrescription { get; set; }
        public int IdMedicament { get; set; }
        public int Dose { get; set; }
        public string Details { get; set; }
        public virtual Medicament Medicament { get; set; }
        public virtual Prescription Prescription { get; set; }

    }
}
