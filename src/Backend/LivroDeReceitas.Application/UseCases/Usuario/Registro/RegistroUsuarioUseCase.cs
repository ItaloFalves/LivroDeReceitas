using LivroDeReceitas.Application.Services.AutoMapper;
using LivroDeReceitas.Application.Services.Criptografia;
using LivroDeReceitas.Communication.Request;
using LivroDeReceitas.Communication.Response;
using LivroDeReceitas.Exceptions.ExceptionsBase;

namespace LivroDeReceitas.Application.UseCases.Usuario.Registro
{
    public class RegistroUsuarioUseCase
    {
        public ResponseRegistroUsuario Executa(RequestRegistroUsuario request)
        {

            Validator(request);

            var autoMapper = new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper();

            var usuario = autoMapper.Map<Domain.Entities.Usuario>(request);

            var criptografiaDeSenha = new PasswordEncripter();
            usuario.Senha = criptografiaDeSenha.Criptografar(request.Senha);

            return new ResponseRegistroUsuario { Nome = request.Nome };

        }

        private void Validator(RequestRegistroUsuario request)
        {
            var registroUsuarioValitador = new RegistroUsuarioValidator();
            var validacao = registroUsuarioValitador.Validate(request);

            if (!validacao.IsValid)
            {
                var mensagemErro = validacao.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(mensagemErro);
            }

        }
    }
}
