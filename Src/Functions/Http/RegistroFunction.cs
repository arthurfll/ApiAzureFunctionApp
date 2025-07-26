using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ApiAzureFunctionApp.Models;
using ApiAzureFunctionApp.Services;
using System.ComponentModel.DataAnnotations;
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
public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
{
    _logger.LogInformation("C# HTTP trigger function processed a request.");

    Aluno? obj = await JsonSerializer.DeserializeAsync<Aluno>(req.Body);

    if (obj == null)
        return new BadRequestObjectResult("Aluno nulo");

    // Valida DataAnnotations
    var context = new ValidationContext(obj);
    var results = new List<ValidationResult>();
    if (!Validator.TryValidateObject(obj, context, results, true))
    {
        var erros = results.Select(r => r.ErrorMessage).ToList();
        return new BadRequestObjectResult(erros);
    }

    await _s.CadastrarAluno(obj);

    return new OkObjectResult(obj);
}
}
