using LivroDeReceitas.Application.UseCases.Usuario.Registro;
using LivroDeReceitas.Communication.Request;
using LivroDeReceitas.Communication.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LivroDeReceitas.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof (ResponseRegistroUsuario), StatusCodes.Status201Created)]
        public IActionResult Registro(RequestRegistroUsuario request)
        {
            var registroUserCase = new RegistroUsuarioUseCase();
            var resultado = registroUserCase.Executa(request);

            return Created(string.Empty, resultado);
        }
    }
}
