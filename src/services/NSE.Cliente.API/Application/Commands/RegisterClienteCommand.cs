using FluentValidation;
using NSE.Core.Messages;
using System;

namespace NSE.Clientes.API.Application.Commands
{
    public class RegisterClienteCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }

        public RegisterClienteCommand(Guid id, string nome, string email, string cpf)
        {
            AggregateId = Id;
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }

        public override bool Valido()
        {
            ValidationResult = new RegisterClienteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RegisterClienteValidation : AbstractValidator<RegisterClienteCommand>
    {
        public RegisterClienteValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.Cpf)
                .Must(TerCpfValido)
                .WithMessage("O CPF informado não é válido inválido");

            RuleFor(c => c.Email)
                .Must(TerEmailValido)
                .WithMessage("O e-mail informado não é válido inválido");
        }

        protected static bool TerCpfValido(string cpf)
        {
            return Core.DomainObjetcs.Cpf.Validar(cpf);
        }

        protected static bool TerEmailValido(string email)
        {
            return Core.DomainObjetcs.Email.Validar(email);
        }
    }
}
