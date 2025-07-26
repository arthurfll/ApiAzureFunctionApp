using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;

namespace ApiAzureFunctionApp.Functions;

public class GetIndexFunction
{
    private readonly ILogger<GetIndexFunction> _logger;

    public GetIndexFunction(ILogger<GetIndexFunction> logger)
    {
        _logger = logger;
    }

    [Function("GetIndexFunction")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        
        var data = new { status = "ok"};
        return new OkObjectResult(data);

    }
}

