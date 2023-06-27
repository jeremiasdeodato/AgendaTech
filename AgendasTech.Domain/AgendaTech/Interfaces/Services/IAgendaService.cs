using AgendasTech.Domain.AgendasTech.Entidades;
using System.Linq.Expressions;

namespace AgendasTech.Domain.AgendaTech.Interfaces.Services
{
    public interface IAgendaService
    {
        Task<Agenda?> Obter(Expression<Func<Agenda, bool>> expression);
        Task<IEnumerable<Agenda>> ObterLista();
        void Inserir(Agenda agenda);
        void Excluir(Agenda agenda);
    }
}
