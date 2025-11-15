using CommonTestUtilities.Requests;
using FluentValidation.Validators;
using LivroDeReceitas.Application.UseCases.Usuario.Registro;
using LivroDeReceitas.Exceptions;
using Shouldly;

namespace Validators.Test.Usuario.Registro
{
    public class RegistroUsuarioValidatorTest
    {
        [Fact]
        public void Sucess()
        {
            var registroUsuarioValitador = new RegistroUsuarioValidator();
            var validacao = RequestRegistroUsuarioBuilder.Build();

            var resultado = registroUsuarioValitador.Validate(validacao);

            resultado.ShouldNotBeNull();
          
        }

        [Fact]
        public void Error_Name_Empty()
        {
            var registroUsuarioValitador = new RegistroUsuarioValidator();
            var validacao = RequestRegistroUsuarioBuilder.Build();
            validacao.Nome = string.Empty;

            var resultado = registroUsuarioValitador.Validate(validacao);

            resultado.IsValid.ShouldBeFalse();
            resultado.Errors.ShouldContain(e => e.PropertyName == "Nome" && e.ErrorMessage.Equals(ResourceMessagesException.NAME_EMPTY));

        }

        [Fact]
        public void Error_Email_Empty()
        {
            var registroUsuarioValitador = new RegistroUsuarioValidator();
            var validacao = RequestRegistroUsuarioBuilder.Build();
            validacao.Email = string.Empty;

            var resultado = registroUsuarioValitador.Validate(validacao);

            resultado.IsValid.ShouldBeFalse();
            resultado.Errors.ShouldContain(e => e.PropertyName == "Email" && e.ErrorMessage.Equals(ResourceMessagesException.EMAIL_EMPTY));

        }

        [Fact]
        public void Error_Email_Invalid()
        {
            var registroUsuarioValitador = new RegistroUsuarioValidator();
            var validacao = RequestRegistroUsuarioBuilder.Build();
            validacao.Email = "email.com";

            var resultado = registroUsuarioValitador.Validate(validacao);

            resultado.IsValid.ShouldBeFalse();
            resultado.Errors.ShouldContain(e => e.PropertyName == "Email" && e.ErrorMessage.Equals(ResourceMessagesException.EMAIL_INVALID));

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Error_Password_Invalid(int passwordLenght)
        {
            var registroUsuarioValitador = new RegistroUsuarioValidator();
            var validacao = RequestRegistroUsuarioBuilder.Build(passwordLenght);

            var resultado = registroUsuarioValitador.Validate(validacao);

            resultado.IsValid.ShouldBeFalse();
            resultado.Errors.ShouldContain(e => e.ErrorMessage.Equals(ResourceMessagesException.PASSWORD_EMPTY));

        }
    }
}
