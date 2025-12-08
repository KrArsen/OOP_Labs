using System.Collections.Generic;

namespace Task_01.Data.Models
{
    public class Medicament
    {
        public Medicament()
        {
            this.Prescriptions = new HashSet<PatientMedicament>();
        }

        public int MedicamentId { get; set; }

        public string Name { get; set; }

        public ICollection<PatientMedicament> Prescriptions { get; set; }
    }
}