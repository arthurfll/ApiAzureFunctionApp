using ApiAzureFunctionApp.Data;
using ApiAzureFunctionApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAzureFunctionApp.Repositories;

public class AlunoRepository
{
  private readonly AppDbContext _db;

  public AlunoRepository(AppDbContext db)
  {
    _db = db;
  }

  public async Task<List<Aluno>> GetRanking()
  {
    List<Aluno> alunos = await _db.Alunos
      .OrderByDescending(x => (double)x.Media)
      .Take(10)
      .ToListAsync();

    return alunos;
  }

  public async Task<Aluno> InsertAluno(Aluno obj)
  {
    await _db.Alunos.AddAsync(obj);
    await _db.SaveChangesAsync();
    return obj;
  }
}

