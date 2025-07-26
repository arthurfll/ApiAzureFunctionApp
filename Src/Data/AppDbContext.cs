using ApiAzureFunctionApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAzureFunctionApp.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }

  public DbSet<Aluno> Alunos { get; set; }
}

