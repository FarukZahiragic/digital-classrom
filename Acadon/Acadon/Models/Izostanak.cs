using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acadon.Models
{
    public class Izostanak
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Naziv učenika: ")]
        [ForeignKey("Korisnik")]
        public int UcenikID { get; set; }

        [ForeignKey("Cas")]
        public int CasID { get; set; }

        [DisplayName("Status izostanka: ")]
        [EnumDataType(typeof(StatusIzostanka))]
        public StatusIzostanka Status { get; set; } = StatusIzostanka.NEOPRAVDAN;

        [StringLength(maximumLength: 50, ErrorMessage =
        "Komentar smije imati maskimalno 50 karaktera!")]
        public string Komentar { get; set; } = "";

        public Izostanak() { }
    }
}