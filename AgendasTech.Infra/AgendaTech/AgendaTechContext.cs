using AgendasTech.Domain.AgendasTech.Entidades;
using AgendasTech.Infra.AgendaTech.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AgendasTech.Infra.Data.AgendaTech
{
    public class AgendaTechContext : DbContext
    {

        public DbSet<Agenda> Agendas { get; set; }

        public AgendaTechContext(DbContextOptions<AgendaTechContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AgendaMapping());
        }
    }
}
