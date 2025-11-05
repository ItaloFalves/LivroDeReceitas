using AutoMapper;
using LivroDeReceitas.Communication.Request;

namespace LivroDeReceitas.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToDomain();
        }

        private void RequestToDomain()
        {
            CreateMap<RequestRegistroUsuario, Domain.Entities.Usuario>()
                .ForMember(dest => dest.Senha, opt => opt.Ignore());
        }
    }
}
