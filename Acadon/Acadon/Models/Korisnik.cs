using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Acadon.Models
{
    public class Korisnik : IdentityUser
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage =
        "Ime smije imati maksimalno 50 karaktera!")]
        [RegularExpression(@"^[A-Za-zÀ-ÖØ-öø-ÿ' -]+$", ErrorMessage =
        "Dozvoljeno je samo korištenje velikih i malih slova, te razmaka!")]
        public string Ime { get; set; } = "";

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage =
        "Ime smije imati maksimalno 50 karaktera!")]
        [RegularExpression(@"^[A-Za-zÀ-ÖØ-öø-ÿ' -]+$", ErrorMessage =
        "Dozvoljeno je samo korištenje velikih i malih slova, te razmaka!")]
        public string Prezime { get; set; } = "";

        [EnumDataType(typeof(StatusVladanja))]
        public StatusVladanja Vladanje { get; set; } = StatusVladanja.PRIMJERNO;

        [ForeignKey("Razred")]
        public int RazredID { get; set; }

        public Korisnik() { }
    }
}
