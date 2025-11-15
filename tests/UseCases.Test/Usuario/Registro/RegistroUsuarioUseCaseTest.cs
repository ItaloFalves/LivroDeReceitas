using CommonTestUtilities.Cryptography;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using LivroDeReceitas.Application.UseCases.Usuario.Registro;
using LivroDeReceitas.Exceptions;
using LivroDeReceitas.Exceptions.ExceptionsBase;
using Shouldly;

namespace UseCases.Test.Usuario.Registro
{
    public class RegistroUsuarioUseCaseTest
    {
        [Fact]
        public async Task Sucess()
        {
            var validacao = RequestRegistroUsuarioBuilder.Build();

            var useCase = CreateUseCase();

            var resultado = await useCase.Executa(validacao);

            resultado.ShouldNotBeNull();
            resultado.Nome.ShouldBe(validacao.Nome);
        }

        [Fact]
        public async Task Error_Email_Already_Registered()
        {
            var validacao = RequestRegistroUsuarioBuilder.Build();

            var useCase = CreateUseCase(validacao.Email);

            Func<Task> act = async () => await useCase.Executa(validacao);

            await act.ShouldThrowAsync<ErrorOnValidationException>();
            
        }

        private RegistroUsuarioUseCase CreateUseCase(string? email = null)
        {
            var mapper = MapperBuilder.Build();
            var passwordEncrypter = PasswordEncripterBuilder.Build();
            var unityOfWork = UnityOfWorkBuilder.Build();
            var writeRepository = UserWriteOnlyRepositoryBuilder.Build();
            var readRepositoryBuilder = new UserReadOnlyRepositoryBuilder();

            if(!string.IsNullOrEmpty(email))
            {
                readRepositoryBuilder.ExistActiveUserWithEmail(email);
            }


            return new RegistroUsuarioUseCase(writeRepository, readRepositoryBuilder.Build(), mapper, passwordEncrypter, unityOfWork);

        }
    }
}
