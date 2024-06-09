using System.ComponentModel.DataAnnotations;

namespace Acadon.Models
{
    public enum StatusVladanja
    {
        [Display(Name = "Primjereno")]
        PRIMJERNO,
        [Display(Name = "Vrlo dobro")]
        VRLODOBRO,
        [Display(Name = "Dobro")]
        DOBRO,
        [Display(Name = "Dovoljno")]
        ZADOVOLJAVA,
        [Display(Name = "Loše")]
        LOSE
    }
}