using AssessmentConvertMeasurments.Models;
using AssessmentConvertMeasurments.Units;

namespace AssessmentConvertMeasurments.Services
{
    public sealed class UnitConversionService
    : IUnitConversionService
    {
        public ConversionResult Convert(ConvertRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            if (string.IsNullOrWhiteSpace(request.From))
                throw new ArgumentException(
                    "'from' unit is required.");

            if (string.IsNullOrWhiteSpace(request.To))
                throw new ArgumentException(
                    "'to' unit is required.");

            if (!UnitCatalog.TryGet(request.From, out var fromUnit))
                throw new KeyNotFoundException(
                    $"Unknown source unit '{request.From}'.");

            if (!UnitCatalog.TryGet(request.To, out var toUnit))
                throw new KeyNotFoundException(
                    $"Unknown target unit '{request.To}'.");

            if (fromUnit!.Category != toUnit!.Category)
            {
                throw new ArgumentException(
                    $"Cannot convert from {fromUnit.Category} " +
                    $"to {toUnit.Category}.");
            }

            var baseValue = fromUnit.ToBase(request.Value);
            var result = toUnit.FromBase(baseValue);

            // Limit floating-style decimal expansion in API responses.
            result = decimal.Round(
                result, 10, MidpointRounding.AwayFromZero);

            return new ConversionResult(
                request.Value,
                fromUnit.Code,
                result,
                toUnit.Code,
                fromUnit.Category);
        }

        public IReadOnlyCollection<UnitDefinition> GetUnits(
            string? category = null)
        {
            if (string.IsNullOrWhiteSpace(category))
                return UnitCatalog.All;

            return UnitCatalog.All
                .Where(unit => string.Equals(
                    unit.Category,
                    category,
                    StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }
    }
}
