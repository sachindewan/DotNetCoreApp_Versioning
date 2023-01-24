using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var groupNameVersion = "'v'VVV";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1.0",
        Description = "API to demonstrate versioning",
        Title = "WebAPI_Versioning",
        TermsOfService = new Uri("https://example.com/Terms"),
        License = new OpenApiLicense
        {
            Name = "WebAPI_Versioning",
            Url = new Uri("https://example.com/v1.0/License")
        },
        Contact = new OpenApiContact
        {
            Name = "WebAPI_Versioning",
            Url = new Uri("https://example.com/v1.0/Contract")
        }
    });
    options.SwaggerDoc("v2", new OpenApiInfo
    {
        Version = "v2.0",
        Description = "API to demonstrate versioning",
        Title = "WebAPI_Versioning2",
        TermsOfService = new Uri("https://example.com/Terms"),
        License = new OpenApiLicense
        {
            Name = "WebAPI_Versioning2",
            Url = new Uri("https://example.com/v2.0/License")
        },
        Contact = new OpenApiContact
        {
            Name = "WebAPI_Versioning2",
            Url = new Uri("https://example.com/v2.0/Contract")
        }
    });
});
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = ApiVersion.Default;
    options.ReportApiVersions = true;
});
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = groupNameVersion;
    options.SubstituteApiVersionInUrl = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI_Versioning_V1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "WebAPI_Versioning_V2");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();