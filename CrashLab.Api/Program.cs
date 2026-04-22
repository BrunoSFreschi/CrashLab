using CrashLab.Domain.Entities;
using CrashLab.Domain.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddLogging();
builder.Services.AddScoped<DocumentProcessor>();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

app.MapPost("/documents/process", (Document doc, DocumentProcessor processor) =>
{
    try
    {
        processor.Process(doc);
        return Results.Ok(new { message = "Processed successfully" });
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

app.Run();