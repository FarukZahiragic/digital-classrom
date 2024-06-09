using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acadon.Models
{
    public class RazredPredmet
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Razred")]
        public int RazredID { get; set; }

        [ForeignKey("Predmet")]
        public int PredmetID { get; set; }

        public RazredPredmet() { }
    }
}