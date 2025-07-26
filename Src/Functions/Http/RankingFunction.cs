using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;
using ApiAzureFunctionApp.Services;
using ApiAzureFunctionApp.Models;

namespace ApiAzureFunctionApp.Functions;

public class RankingFunction
{
    private readonly ILogger<RankingFunction> _logger;
    private readonly AlunoService _s;

    public RankingFunction(ILogger<RankingFunction> logger, AlunoService s)
    {
        _logger = logger;
        _s = s;
    }

    [Function("RankingFunction")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        List<Aluno> data = await _s.RankingAlunos();

        return new OkObjectResult(data);

    }
}


