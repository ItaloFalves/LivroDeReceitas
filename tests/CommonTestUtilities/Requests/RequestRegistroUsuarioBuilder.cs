using Bogus;
using LivroDeReceitas.Communication.Request;

namespace CommonTestUtilities.Requests
{
    public static class RequestRegistroUsuarioBuilder
    {
        public static RequestRegistroUsuario Build(int passwordLenght = 10)
        {
            return new Faker<RequestRegistroUsuario>()
                .RuleFor(user => user.Nome, (f) => f.Person.FirstName)
                .RuleFor(user => user.Email, (f, u) => f.Internet.Email(u.Nome))
                .RuleFor(user => user.Senha, (f) => f.Internet.Password(passwordLenght));
        }
    }
}
