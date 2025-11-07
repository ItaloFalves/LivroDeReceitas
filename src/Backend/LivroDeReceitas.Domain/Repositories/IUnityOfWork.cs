namespace LivroDeReceitas.Domain.Repositories
{
    public interface IUnityOfWork
    {
        public Task Commit();
    }
}
