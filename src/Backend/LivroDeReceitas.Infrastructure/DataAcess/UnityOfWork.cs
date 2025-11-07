using LivroDeReceitas.Domain.Repositories;

namespace LivroDeReceitas.Infrastructure.DataAcess
{
    public class UnityOfWork : IUnityOfWork
    {

        private readonly LivroDeReceitasDbContext _dbContext;

        public UnityOfWork(LivroDeReceitasDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task Commit() => await _dbContext.SaveChangesAsync();
    }
}
