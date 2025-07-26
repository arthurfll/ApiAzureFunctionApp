using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using ApiAzureFunctionApp.Models;
using ApiAzureFunctionApp.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ApiAzureFunctionApp.Functions
{
    public class QueueRegistroFunction
    {
        private readonly ILogger<QueueRegistroFunction> _logger;
        private readonly AlunoService _s;

        public QueueRegistroFunction(ILogger<QueueRegistroFunction> logger, AlunoService s)
        {
            _logger = logger;
            _s = s;
        }

        public async Task Run(
    [QueueTrigger("queue", Connection = "AzureWebJobsStorage")] string message,
    CancellationToken cancellationToken)
        {
            _logger.LogInformation("Processando aluno da fila.");

            try
            {
                var json = message; 

                var aluno = JsonSerializer.Deserialize<AlunoQueueMessage>(json);

                if (aluno == null)
                {
                    _logger.LogError("Mensagem inválida: desserialização retornou null.");
                    return;
                }

                var alunoEntity = new Aluno
                {
                    Nome = aluno.Nome,
                    Nota1 = aluno.Nota1,
                    Nota2 = aluno.Nota2,
                    Nota3 = aluno.Nota3,
                    Nota4 = aluno.Nota4
                };

                await _s.CadastrarAluno(alunoEntity);

                _logger.LogInformation($"Aluno {aluno.Nome} salvo com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao processar mensagem da fila: {ex.Message}");
            }
        }
    }
}

public class AlunoQueueMessage
{
    public string Nome { get; set; }
    public int Nota1 { get; set; }
    public int Nota2 { get; set; }
    public int Nota3 { get; set; }
    public int Nota4 { get; set; }
}

