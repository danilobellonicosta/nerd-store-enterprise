using System;
using System.Collections.Generic;
using System.Text;

namespace NSE.Core.Messages.Integration
{
    public abstract class IntegrationEvent : Event
    {
    }

    public class UsuarioRegistradoIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }

        public UsuarioRegistradoIntegrationEvent(Guid id, string nome, string email, string cpf)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }
    }
}
