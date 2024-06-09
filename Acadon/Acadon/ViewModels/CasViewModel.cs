using Acadon.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Acadon.ViewModels
{
    public class CasViewModel
    {
        public int ID { get; set; }

        [DisplayName("Naziv predmeta: ")]
        public string PredmetNaziv { get; set; }

        [DisplayName("Naziv razreda: ")]
        public string RazredNaziv { get; set; }

        [DisplayName("Termin održavanja prvog časa: ")]
        [ValidateTime]
        [DataType(DataType.Date)]
        public DateTime Vrijeme { get; set; }
    }
}
