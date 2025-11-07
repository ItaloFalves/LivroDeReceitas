using AutoMapper;
using LivroDeReceitas.Application.Services.Criptografia;
using LivroDeReceitas.Communication.Request;
using LivroDeReceitas.Communication.Response;
using LivroDeReceitas.Domain.Repositories;
using LivroDeReceitas.Domain.Repositories.Usuario;
using LivroDeReceitas.Exceptions;
using LivroDeReceitas.Exceptions.ExceptionsBase;

namespace LivroDeReceitas.Application.UseCases.Usuario.Registro
{
    public class RegistroUsuarioUseCase : IRegistroUsuarioUseCase
    {
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IMapper _mapper;
        private readonly PasswordEncripter _passwordEncripter;
        private readonly IUnityOfWork _unityOfWork;

        public RegistroUsuarioUseCase(IUserWriteOnlyRepository userWriteOnlyRepository, IUserReadOnlyRepository userReadOnlyRepository, 
            IMapper mapper, PasswordEncripter passwordEncripter, IUnityOfWork unityOfWork)
        {
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _userReadOnlyRepository = userReadOnlyRepository;
            _mapper = mapper;
            _passwordEncripter = passwordEncripter;
            _unityOfWork = unityOfWork;
        }

        public async Task<ResponseRegistroUsuario> Executa(RequestRegistroUsuario request)
        {

            await Validator(request);

            var usuario = _mapper.Map<Domain.Entities.Usuario>(request);
            usuario.Senha = _passwordEncripter.Criptografar(request.Senha);

            await _userWriteOnlyRepository.Add(usuario);

            await _unityOfWork.Commit();

            return new ResponseRegistroUsuario { Nome = request.Nome };

        }

        private async Task Validator(RequestRegistroUsuario request)
        {
            var registroUsuarioValitador = new RegistroUsuarioValidator();
            var validacao = registroUsuarioValitador.Validate(request);

            var existeEmail = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);

            if (existeEmail)
            {
                validacao.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceMessagesException.EMAIL_ALREADY_REGISTERED));
            }

            if (!validacao.IsValid)
            {
                var mensagemErro = validacao.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(mensagemErro);
            }

        }
    }
}
