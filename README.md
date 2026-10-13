AssessmentConvertMeasurments

Project Overview

AssessmentConvertMeasurments is an ASP.NET Core Web API that converts numerical values between different units of measurement.

Technologies Used
C#
ASP.NET Core Web API
.NET 8
REST API
JSON
Supported Conversions
Length: Meters, Kilometers, Feet, Inches, Miles
Temperature: Celsius, Fahrenheit, Kelvin
Mass: Kilograms, Grams, Pounds, Ounces
Area: Square Meters, Square Feet, Acres
Volume: Liters, Milliliters, Gallons
Speed: Meters/Second, Kilometers/Hour, MPH
Time: Seconds, Minutes, Hours, Days
Digital Storage: Bytes, KB, MB, GB
Pressure: Pascal, Bar, PSI
Energy: Joules, Calories, kWh
Project Structure
Models: Request and response models.
Units: Unit definitions and hardcoded conversion factors.
Services: Conversion logic and service interface.
Program.cs: Configures the API endpoints and dependency injection.
How to Run the Project
Using Visual Studio
Open the project or solution in Visual Studio.
Set UnitConverter.Api as the startup project.
Build the solution.
Press F5 or Ctrl+F5 to run the application.
Using Command Line

Navigate to the folder containing UnitConverter.Api.csproj and execute:

dotnet restore
dotnet build
dotnet run


Use the URL displayed in the terminal to access the API.

API Endpoints
1. Convert Units

POST /api/v1/conversions

Example request:

{
  "value": 100,
  "from": "m",
  "to": "ft"
}

2. Get Supported Units

GET /api/v1/units

Filter by category:

GET /api/v1/units?category=Length

3. Get Supported Categories

GET /api/v1/categories

Conversion Logic

The API converts values through a common base unit for each measurement category using conversion factors and offsets.

This approach avoids implementing separate conversion methods for every pair of units and makes it easy to add more units in the future.

Error Handling
200 OK – Conversion successful.
400 Bad Request – Invalid or incompatible units.
404 Not Found – Unknown unit or category.
Future Enhancements
Database-backed unit management.
Automated unit and integration tests.
Swagger/OpenAPI documentation.
Centralized error handling and logging.
Support for additional conversion types.
Author

UnitsConverterAssessment Project
