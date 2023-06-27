namespace AgendasTech.Application.AgendaTech.Models
{
    public class AgendaListaViewModel
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public bool Ativo { get; set; }
    }
}
