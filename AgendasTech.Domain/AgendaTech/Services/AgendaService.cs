using AgendasTech.Domain.AgendasTech.Entidades;
using AgendasTech.Domain.AgendaTech.Interfaces.Repositories;
using AgendasTech.Domain.AgendaTech.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AgendasTech.Domain.AgendaTech.Services
{
    public class AgendaService : IAgendaService
    {
        private readonly IAgendaRepository _repository;

        public AgendaService(IAgendaRepository repository)
        {
            _repository = repository;
        }
        public void Inserir(Agenda agenda)
        {
            _repository.Inserir(agenda);
        }

        public void Excluir(Agenda agenda)
        {
            _repository.Excluir(agenda);
        }

        public Task<Agenda?> Obter(Expression<Func<Agenda, bool>> expression)
        {
            return _repository.Obter().FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<Agenda>> ObterLista()
        {
            return await _repository.Obter().ToListAsync();
        }

    }
}
