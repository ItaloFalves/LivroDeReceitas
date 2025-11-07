using LivroDeReceitas.Application.Services.AutoMapper;
using LivroDeReceitas.Application.Services.Criptografia;
using LivroDeReceitas.Application.UseCases.Usuario.Registro;
using Microsoft.Extensions.DependencyInjection;

namespace LivroDeReceitas.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddAplication(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddUseCases(services);
            AddPasswordEncripter(services);
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            var autoMapper = new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper();

            services.AddScoped(opt => autoMapper);
        }

        private static void AddUseCases(IServiceCollection services) 
        {
            services.AddScoped<IRegistroUsuarioUseCase, RegistroUsuarioUseCase>();
        }

        private static void AddPasswordEncripter(IServiceCollection services)
        {
            services.AddScoped(opt => new PasswordEncripter());
        }
    }
}
