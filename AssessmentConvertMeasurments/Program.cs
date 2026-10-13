using AssessmentConvertMeasurments.Models;
using AssessmentConvertMeasurments.Services;
using AssessmentConvertMeasurments.Units;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<
IUnitConversionService,
UnitConversionService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/", () => Results.Ok(new
{
    name = "Unit Converter API",
    version = "v1",
    endpoints = new[]
    {
        "POST /api/v1/conversions",
        "GET /api/v1/units",
        "GET /api/v1/categories"
    }
}));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// Convert a value between compatible units.
app.MapPost(
    "/api/v1/conversions",
    (ConvertRequest? request, IUnitConversionService service) =>
    {
        if (request is null)
        {
            return Results.BadRequest(new
            {
                error = "A request body is required."
            });
        }

        try
        {
            var result = service.Convert(request);
            return Results.Ok(result);
        }
        catch (ArgumentException ex)
        {
            return Results.BadRequest(new
            {
                error = ex.Message
            });
        }
        catch (KeyNotFoundException ex)
        {
            return Results.NotFound(new
            {
                error = ex.Message
            });
        }
        catch (OverflowException)
        {
            return Results.BadRequest(new
            {
                error = "The value is outside the supported range."
            });
        }
    });

// List all units or filter by category.
app.MapGet(
    "/api/v1/units",
    (string? category, IUnitConversionService service) =>
    {
        var units = service.GetUnits(category);

        if (!string.IsNullOrWhiteSpace(category) &&
            units.Count == 0)
        {
            return Results.NotFound(new
            {
                error = $"Unknown category '{category}'."
            });
        }

        return Results.Ok(units.Select(unit => new
        {
            unit.Code,
            unit.Name,
            unit.Category
        }));
    });

// List distinct categories.
app.MapGet(
    "/api/v1/categories",
    () =>
    {
        var categories = UnitCatalog.All
            .Select(unit => unit.Category)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(category => category);

        return Results.Ok(categories);
    });

app.Run();
