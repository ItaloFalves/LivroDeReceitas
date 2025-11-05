using FluentValidation;
using LivroDeReceitas.Communication.Request;
using LivroDeReceitas.Exceptions;

namespace LivroDeReceitas.Application.UseCases.Usuario.Registro
{
    public class RegistroUsuarioValidator : AbstractValidator<RequestRegistroUsuario>
    {
        public RegistroUsuarioValidator()
        {
            RuleFor(usuario => usuario.Nome).NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);
            RuleFor(usuario => usuario.Email).NotEmpty().WithMessage(ResourceMessagesException.EMAIL_EMPTY);
            RuleFor(usuario => usuario.Email).EmailAddress().WithMessage(ResourceMessagesException.EMAIL_INVALID);
            RuleFor(usuario => usuario.Senha.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMessagesException.PASSWORD_EMPTY);
        }
    }
}
