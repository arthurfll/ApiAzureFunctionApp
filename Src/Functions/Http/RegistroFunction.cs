using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ApiAzureFunctionApp.Models;
using ApiAzureFunctionApp.Services;
using System.ComponentModel.DataAnnotations;
using Azure.Storage.Queues;
namespace ApiAzureFunctionApp.Functions;

public class RegistroFunction
{

    private readonly ILogger<RegistroFunction> _logger;
    private readonly AlunoService _s;

    public RegistroFunction(ILogger<RegistroFunction> logger, AlunoService s)
    {
        _logger = logger;
        _s = s;
    }


[Function("RegistroFunction")]
public async Task<IActionResult> Run(
    [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
{
    _logger.LogInformation("Recebendo aluno via HTTP.");

    var aluno = await JsonSerializer.DeserializeAsync<AlunoQueueMessage>(req.Body);

    if (aluno == null)
        return new BadRequestObjectResult("Aluno nulo");

    var context = new ValidationContext(aluno);
    var results = new List<ValidationResult>();
    if (!Validator.TryValidateObject(aluno, context, results, true))
    {
        var erros = results.Select(r => r.ErrorMessage).ToList();
        return new BadRequestObjectResult(erros);
    }

    var connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
    var queueClient = new QueueClient(connectionString, "queue");
    await queueClient.CreateIfNotExistsAsync();

    var json = JsonSerializer.Serialize(aluno);
    await queueClient.SendMessageAsync(json);


    return new OkObjectResult("Aluno enfileirado com sucesso.");
}
}


