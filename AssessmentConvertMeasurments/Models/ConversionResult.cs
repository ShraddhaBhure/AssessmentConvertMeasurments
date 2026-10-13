namespace AssessmentConvertMeasurments.Models
{
    public sealed record ConversionResult(
     decimal InputValue,
     string From,
     decimal Result,
     string To,
     string Category
 );
}
