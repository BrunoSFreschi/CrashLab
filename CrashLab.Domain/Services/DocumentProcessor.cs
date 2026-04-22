using CrashLab.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace CrashLab.Domain.Services;

public class DocumentProcessor
{
    private readonly ILogger<DocumentProcessor> _logger;

    public DocumentProcessor(ILogger<DocumentProcessor> logger)
    {
        _logger = logger;
    }

    public void Process(Document document)
    {
        Normalize(document);
        Validate(document);
        Execute(document);
    }

    private void Normalize(Document document)
    {
        document.Type = document.Type?.ToLower();
    }

    private void Validate(Document document)
    {
        if (string.IsNullOrEmpty(document.Type))
            throw new Exception("Type is required");

        if (document.Customer == null)
            throw new Exception("Customer is required");

        // BUG: validação incompleta proposital
        if (document.Type == "invoice" && string.IsNullOrEmpty(document.Customer.Name))
            throw new Exception("Customer name is required");
    }

    private void Execute(Document document)
    {
        if (document.Type == "invoice")
        {
            // BUG (NullReference intermitente)
            var city = document.Customer.Address.City;

            _logger.LogInformation("Processing invoice for {City}", city);
        }
    }
}