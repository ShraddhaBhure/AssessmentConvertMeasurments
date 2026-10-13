namespace AssessmentConvertMeasurments.Units
{
    public static class UnitCatalog
    {
        private static readonly UnitDefinition[] Definitions =
        [
            // Length: base unit = meter
            new("m", "Meter", "Length", 1m),
        new("km", "Kilometer", "Length", 1000m),
        new("cm", "Centimeter", "Length", 0.01m),
        new("mm", "Millimeter", "Length", 0.001m),
        new("mi", "Mile", "Length", 1609.344m),
        new("ft", "Foot", "Length", 0.3048m),
        new("in", "Inch", "Length", 0.0254m),
        new("yd", "Yard", "Length", 0.9144m),

        // Temperature: base unit = Celsius
        new("C", "Celsius", "Temperature", 1m),
        new("F", "Fahrenheit", "Temperature",
            5m / 9m, -160m / 9m),
        new("K", "Kelvin", "Temperature",
            1m, -273.15m),

        // Mass: base unit = kilogram
        new("kg", "Kilogram", "Mass", 1m),
        new("g", "Gram", "Mass", 0.001m),
        new("mg", "Milligram", "Mass", 0.000001m),
        new("lb", "Pound", "Mass", 0.45359237m),
        new("oz", "Ounce", "Mass", 0.028349523125m),
        new("t", "Metric Tonne", "Mass", 1000m),

        // Area: base unit = square meter
        new("m2", "Square Meter", "Area", 1m),
        new("km2", "Square Kilometer", "Area", 1_000_000m),
        new("ft2", "Square Foot", "Area", 0.09290304m),
        new("acre", "Acre", "Area", 4046.8564224m),
        new("ha", "Hectare", "Area", 10000m),

        // Volume: base unit = liter
        new("L", "Liter", "Volume", 1m),
        new("mL", "Milliliter", "Volume", 0.001m),
        new("m3", "Cubic Meter", "Volume", 1000m),
        new("gal", "US Gallon", "Volume", 3.785411784m),
        new("cup", "US Cup", "Volume", 0.2365882365m),

        // Speed: base unit = meter per second
        new("m/s", "Meter per Second", "Speed", 1m),
        new("km/h", "Kilometer per Hour", "Speed", 1m / 3.6m),
        new("mph", "Mile per Hour", "Speed", 0.44704m),
        new("ft/s", "Foot per Second", "Speed", 0.3048m),

        // Time: base unit = second
        new("s", "Second", "Time", 1m),
        new("min", "Minute", "Time", 60m),
        new("h", "Hour", "Time", 3600m),
        new("day", "Day", "Time", 86400m),

        // Digital storage: base unit = byte
        new("B", "Byte", "Digital Storage", 1m),
        new("KB", "Kilobyte", "Digital Storage", 1000m),
        new("MB", "Megabyte", "Digital Storage", 1_000_000m),
        new("GB", "Gigabyte", "Digital Storage", 1_000_000_000m),
        new("KiB", "Kibibyte", "Digital Storage", 1024m),
        new("MiB", "Mebibyte", "Digital Storage", 1_048_576m),

        // Pressure: base unit = Pascal
        new("Pa", "Pascal", "Pressure", 1m),
        new("kPa", "Kilopascal", "Pressure", 1000m),
        new("bar", "Bar", "Pressure", 100000m),
        new("psi", "Pound per Square Inch", "Pressure",
            6894.757293168m),

        // Energy: base unit = Joule
        new("J", "Joule", "Energy", 1m),
        new("kJ", "Kilojoule", "Energy", 1000m),
        new("cal", "Calorie", "Energy", 4.184m),
        new("kcal", "Kilocalorie", "Energy", 4184m),
        new("kWh", "Kilowatt-hour", "Energy", 3_600_000m)
        ];

        private static readonly Dictionary<string, UnitDefinition> ByCode =
            Definitions.ToDictionary(
                unit => unit.Code,
                StringComparer.OrdinalIgnoreCase);

        public static IReadOnlyCollection<UnitDefinition> All =>
            Definitions;

        public static bool TryGet(
            string code,
            out UnitDefinition? unit)
        {
            return ByCode.TryGetValue(code, out unit);
        }
    }
}
