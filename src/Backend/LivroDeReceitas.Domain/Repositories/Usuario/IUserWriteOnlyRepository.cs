namespace LivroDeReceitas.Domain.Repositories.Usuario
{
    public interface IUserWriteOnlyRepository
    {
        public Task Add(Entities.Usuario usuario);
    }
}
