using System.ComponentModel.DataAnnotations;

namespace ApiAzureFunctionApp.Models;

public class Aluno
{
  [Key]
  public Guid Id { get; set; }
  [MinLength(3), MaxLength(50)]
  public string Nome { get; set; }
  [Range(0, 10)]
  public int Nota1 { get; set; }
  [Range(0, 10)]
  public int Nota2 { get; set; }
  [Range(0, 10)]
  public int Nota3 { get; set; }
  [Range(0, 10)]
  public int Nota4 { get; set; }
  public decimal Media { get; set; }
}

