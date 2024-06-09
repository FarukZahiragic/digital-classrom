using System.ComponentModel.DataAnnotations;

namespace Acadon.Models
{
    public enum StatusIzostanka
    {
        [Display(Name = "Opravdan")]
        OPRAVDAN,
        [Display(Name = "Neopravdan")]
        NEOPRAVDAN
    }
}