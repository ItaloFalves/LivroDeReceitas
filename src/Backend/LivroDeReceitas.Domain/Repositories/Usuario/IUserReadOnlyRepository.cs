namespace LivroDeReceitas.Domain.Repositories.Usuario
{
    public interface IUserReadOnlyRepository
    {
        public Task<bool> ExistActiveUserWithEmail(string email);
    }
}
