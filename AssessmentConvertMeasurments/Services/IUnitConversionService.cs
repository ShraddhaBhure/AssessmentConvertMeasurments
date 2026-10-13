using AssessmentConvertMeasurments.Models;
using AssessmentConvertMeasurments.Units;

namespace AssessmentConvertMeasurments.Services
{
    public interface IUnitConversionService
    {
        ConversionResult Convert(ConvertRequest request);

        IReadOnlyCollection<UnitDefinition> GetUnits(
            string? category = null);
    }
}
