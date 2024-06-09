using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acadon.Models
{
    public class Cas
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Naziv predmeta: ")]
        [ForeignKey("Predmet")]
        public int PredmetID { get; set; }

        [DisplayName("Naziv razreda: ")]
        [ForeignKey("Razred")]
        public int RazredID { get; set; }

        [DisplayName("Termin održavanja prvog časa: ")]
        [ValidateTime]
        [DataType(DataType.Date)]
        public DateTime Vrijeme { get; set; }

        // Navigation properties
        public Predmet Predmet { get; set; }
        public Razred Razred { get; set; }

        public Cas() { }
    }
}