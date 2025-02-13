
using ProjetoConsulta.Models;

namespace ProjetoConsulta.Repositories.Especialidades
{
  public interface IEspecialidadeRepository
  {
    Task<List<Especialidade>> GetAllAsync();
  }
}
