using AgendasTech.Domain.AgendasTech.Entidades;
using AgendasTech.Domain.AgendaTech.Interfaces.Repositories;
using AgendasTech.Infra.Data.AgendaTech;
using Microsoft.EntityFrameworkCore;

namespace AcademiaMktEscolas.Infra.Data.AcademiaMkt.Repositories
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly AgendaTechContext _contexto;
        private readonly DbSet<Agenda> _dbSet;

        public AgendaRepository(AgendaTechContext contexto)
        {
            _contexto = contexto;
            _dbSet = _contexto.Agendas;
        }

        public IQueryable<Agenda> Obter()
        {
            return _dbSet.AsQueryable();
        }

        public void Inserir(Agenda agenda)
        {
            _dbSet.Add(agenda);
        }        

        public void Excluir(Agenda agenda)
        {
            _dbSet.Remove(agenda);
        }
    }
}
