using AgendasTech.Domain.AgendasTech.Entidades;
using AgendasTech.Domain.Core.Interfaces;

namespace AgendasTech.Domain.AgendaTech.Interfaces.Repositories
{
    public interface IAgendaRepository : IRepositoryBase<Agenda>
    {
        void Excluir(Agenda agenda);
    }
}
