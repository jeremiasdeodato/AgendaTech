using AgendasTech.Domain.AgendasTech.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendasTech.Infra.AgendaTech.Mapping
{
    internal class AgendaMapping : IEntityTypeConfiguration<Agenda>
    {

        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.ToTable("agenda");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Telefone)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Ativo)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(x => x.DataCriacao)
                .HasColumnType("datetime");
        }
    }
}
