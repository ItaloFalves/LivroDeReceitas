using LivroDeReceitas.Communication.Request;
using LivroDeReceitas.Communication.Response;

namespace LivroDeReceitas.Application.UseCases.Usuario.Registro
{
    public class RegistroUsuarioUseCase
    {
        public ResponseRegistroUsuario Executa(RequestRegistroUsuario request)
        {

            Validator(request);

            return new ResponseRegistroUsuario { Nome = request.Nome };

        }

        private void Validator(RequestRegistroUsuario request)
        {
            var registroUsuarioValitador = new RegistroUsuarioValidator();
            var validacao = registroUsuarioValitador.Validate(request);

            if (!validacao.IsValid)
            {
                var mensagemErro = validacao.Errors.Select(e => e.ErrorMessage);
                throw new Exception(mensagemErro.ToString());
            }

        }
    }
}
