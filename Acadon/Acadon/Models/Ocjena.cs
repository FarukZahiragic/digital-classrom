using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acadon.Models
{
    public class Ocjena
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Naziv učenika: ")]
        [ForeignKey("Korisnik")]
        public int UcenikID { get; set; }

        [ForeignKey("Cas")]
        public int CasID { get; set; }

        [DisplayName("Ocjena: ")]
        [EnumDataType(typeof(VrijednostOcjene))]
        public VrijednostOcjene Vrijednost { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage =
        "Komentar smije imati maskimalno 50 karaktera!")]
        public string Komentar { get; set; } = "";

        public Ocjena() { }
    }
}