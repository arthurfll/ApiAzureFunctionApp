using System;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ApiAzureFunctionApp.Functions;

public class QueueRegistroFunction
{
    private readonly ILogger<QueueRegistroFunction> _logger;

    public QueueRegistroFunction(ILogger<QueueRegistroFunction> logger)
    {
        _logger = logger;
    }

    [Function(nameof(QueueRegistroFunction))]
    public void Run([QueueTrigger("myqueue-items", Connection = "")] QueueMessage message)
    {
        _logger.LogInformation("C# Queue trigger function processed: {messageText}", message.MessageText);
    }
}