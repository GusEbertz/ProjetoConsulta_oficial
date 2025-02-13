using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using ProjetoConsulta.Extensions;
using ProjetoConsulta.Models;
using ProjetoConsulta.Repositories.Especialidades;
using ProjetoConsulta.Repositories.Medicos;

namespace ProjetoConsulta.Components.Pages.Medicos
{
  public class CreateMedicoPage : ComponentBase
  {
    [Inject]
    private IEspecialidadeRepository EspecialidadeRepository { get; set; } = null!;

    [Inject]
    public IMedicoRepository repository { get; set; } = default!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    public List<Especialidade> Especialidades { get; set; } = new();
    public MedicoInputModel InputModel { get; set; } = new();

    public async Task OnValidSubmitAsync(EditContext editContext)
    {
      try
      {
        if (editContext.Model is MedicoInputModel model)
        {
          var medico = new Medico
          {
            Nome = model.Nome,
            Documento = model.Documento.SomenteCaracteres(),
            Celular = model.Celular.SomenteCaracteres(),
            Crm = model.Crm.SomenteCaracteres(),
            EspecialidadeId = model.EspecialidadeId,
            DataCadastro = model.DataCadastro
          };

          await repository.AddAsync(medico);
          Snackbar.Add("Médico cadastrado com sucesso!", Severity.Success);
          NavigationManager.NavigateTo("/medicos");
        }
      }
      catch (Exception ex)
      {
        Snackbar.Add(ex.Message, Severity.Error);
      }
    }

    protected override async Task OnInitializedAsync()
    {
      Especialidades = await EspecialidadeRepository.GetAllAsync();
    }

  }
}
