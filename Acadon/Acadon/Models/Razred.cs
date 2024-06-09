using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acadon.Models
{
    public class Razred
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Naziv razreda: ")]
        public string Naziv { get; set; } = "";

        [DisplayName("Ime razrednika: ")]
        [ForeignKey("Korisnik")]
        public int RazrednikID { get; set; }

        public Razred() { }
    }
}