using AgendasTech.Domain.Core.Entidades;

namespace AgendasTech.Domain.AgendasTech.Entidades
{
    public class Agenda : EntidadeBase
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }

        protected Agenda() : base() { }

        public Agenda(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public void AtualizarNome(string nome)
        {
            Nome = nome;
        }

        public void AtualizarEmail(string email)
        {
            Email = email;
        }

        public void AtualizarTelefone(string telefone)
        {
            Telefone = telefone;
        }

        private string? ValidarAgenda()
        {            
            if (Nome == null)
                return $"Campo {nameof(Nome)} é obrigatório e não pode ser nulo.";

            if (Email == null)
                return $"Campo {nameof(Email)} é obrigatório e não pode ser nulo.";

            if (Telefone == null)
                return $"Campo {nameof(Telefone)} é obrigatório e não pode ser nulo.";

            return null;
        }

        public override bool EhValido()
        {   
            return ValidarAgenda() == null;
        }

        public override string? MensagemValidacao()
        {
            var validarAgenda = ValidarAgenda();

            if (validarAgenda == null)
                return null;
            else
                return validarAgenda;            
        }
    }
}
