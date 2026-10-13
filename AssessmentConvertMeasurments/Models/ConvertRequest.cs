using System.ComponentModel.DataAnnotations;

namespace AssessmentConvertMeasurments.Models
{
    public sealed record ConvertRequest(
     [Required] decimal Value,
     [Required] string From,
     [Required] string To
 );
}
