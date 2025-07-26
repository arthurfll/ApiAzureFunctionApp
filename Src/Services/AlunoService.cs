using ApiAzureFunctionApp.Models;
using ApiAzureFunctionApp.Repositories;

namespace ApiAzureFunctionApp.Services;

public class AlunoService
{
  private readonly AlunoRepository _r;
  public AlunoService(AlunoRepository r)
  {
    _r = r;
  }

  public async Task<Aluno> CadastrarAluno(Aluno obj)
  {
    obj.Media = (obj.Nota1 + obj.Nota2 + obj.Nota3 + obj.Nota4) / 4;
    await _r.InsertAluno(obj);
    return obj;
  }

  public async Task<List<Aluno>> RankingAlunos()
  {
    var data = await _r.GetRanking();
    return data;
  }
}

