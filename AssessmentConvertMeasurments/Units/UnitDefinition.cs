namespace AssessmentConvertMeasurments.Units
{
    public sealed record UnitDefinition(
    string Code,
    string Name,
    string Category,
    decimal Factor,
    decimal Offset = 0m
)
    {
        // Converts this unit into its category's base unit.
        public decimal ToBase(decimal value)
            => value * Factor + Offset;

        // Converts from the category's base unit into this unit.
        public decimal FromBase(decimal value)
            => (value - Offset) / Factor;
    }
}
