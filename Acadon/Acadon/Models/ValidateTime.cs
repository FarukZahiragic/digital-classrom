using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Acadon.Models
{
    public class ValidateTime : ValidationAttribute
    {
        protected override ValidationResult? IsValid
        (object date, ValidationContext validationContext)
        {
            TimeSpan start = new TimeSpan(8, 0, 0);
            TimeSpan end = new TimeSpan(20, 0, 0);
            return (((DateTime)date).TimeOfDay >= start &&
           ((DateTime)date).TimeOfDay <= end)
            ? ValidationResult.Success
            : new ValidationResult("Validan je termin početka časa između 8:00 i 20:00!");
        }
    }
}
