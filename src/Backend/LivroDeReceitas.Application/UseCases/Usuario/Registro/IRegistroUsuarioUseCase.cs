using LivroDeReceitas.Communication.Request;
using LivroDeReceitas.Communication.Response;

namespace LivroDeReceitas.Application.UseCases.Usuario.Registro
{
    public interface IRegistroUsuarioUseCase 
    {
        public Task<ResponseRegistroUsuario> Executa(RequestRegistroUsuario request);
    }
}
