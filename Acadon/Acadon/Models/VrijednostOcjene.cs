using System.ComponentModel.DataAnnotations;

namespace Acadon.Models
{
    public enum VrijednostOcjene
    {
        [Display(Name = "Odličan(5)")]
        PET,
        [Display(Name = "Vrlo dobar(4)")]
        CETIRI,
        [Display(Name = "Dobar(3)")]
        TRI,
        [Display(Name = "Dovoljan(2)")]
        DVA,
        [Display(Name = "Nedovoljan(1)")]
        JEDAN
    }
}
