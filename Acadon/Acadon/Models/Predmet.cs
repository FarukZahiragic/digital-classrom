using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acadon.Models
{
    public class Predmet
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage =
        "Naziv predmeta smije imati između 3 i 50 karaktera!")]
        [RegularExpression(@"[0-9| |a-z|A-Z]*", ErrorMessage = 
        "Dozvoljeno je samo korištenje velikih i malih slova, brojeva i razmaka!")]
        [DisplayName("Naziv predmeta:")]
        public string Naziv { get; set; } = "";

        [DisplayName("Naziv nastavnika: ")]
        [ForeignKey("Korisnik")]
        public int NastavnikID { get; set; }

        public Predmet() { }
    }
}