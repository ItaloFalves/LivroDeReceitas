using FluentValidation;
using LivroDeReceitas.Communication.Request;

namespace LivroDeReceitas.Application.UseCases.Usuario.Registro
{
    public class RegistroUsuarioValidator : AbstractValidator<RequestRegistroUsuario>
    {
        public RegistroUsuarioValidator()
        {
            RuleFor(usuario => usuario.Nome).NotEmpty();
            RuleFor(usuario => usuario.Email).NotEmpty();
            RuleFor(usuario => usuario.Email).EmailAddress();
            RuleFor(usuario => usuario.Senha.Length).GreaterThanOrEqualTo(6);
        }
    }
}
