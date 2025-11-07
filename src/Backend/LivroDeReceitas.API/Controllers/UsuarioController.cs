using LivroDeReceitas.Application.UseCases.Usuario.Registro;
using LivroDeReceitas.Communication.Request;
using LivroDeReceitas.Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace LivroDeReceitas.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof (ResponseRegistroUsuario), StatusCodes.Status201Created)]
        public async Task<IActionResult> Registro([FromServices]IRegistroUsuarioUseCase registroUsuarioUseCase ,[FromBody]RequestRegistroUsuario request)
        {

            var resultado = await registroUsuarioUseCase.Executa(request);

            return Created(string.Empty, resultado);
        }
    }
}
