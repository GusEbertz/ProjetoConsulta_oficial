using ProjetoConsulta.Models;

namespace ProjetoConsulta.Repositories.Medicos
{
  public interface IMedicoRepository
  {
    Task AddAsync(Medico medico);
    Task UpdateAsync(Medico medico);
    Task<List<Medico>> GetAllAsync();
    Task<Medico?> GetByIdAsync(int id);
    Task DeleteByIdAsync(int id);
  }
}
