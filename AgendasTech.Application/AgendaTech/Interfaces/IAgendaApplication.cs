using AgendasTech.Application.AgendaTech.Models;

namespace AgendasTech.Application.AgendaTech.Interfaces
{
    public interface IAgendaApplication
    {
        Task<IEnumerable<AgendaListaViewModel>> Obter();
        Task<AgendaViewModel?> Obter(Guid id);
        Task Inserir(AgendaViewModel viewModel);
        Task Atualizar(Guid id, AgendaViewModel viewModel);
        Task Excluir(Guid id);
    }
}
