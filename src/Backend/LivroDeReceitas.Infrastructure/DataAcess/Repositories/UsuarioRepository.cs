using LivroDeReceitas.Domain.Entities;
using LivroDeReceitas.Domain.Repositories.Usuario;
using Microsoft.EntityFrameworkCore;

namespace LivroDeReceitas.Infrastructure.DataAcess.Repositories
{
    public class UsuarioRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
    {
        private readonly LivroDeReceitasDbContext _dbContext;

        public UsuarioRepository(LivroDeReceitasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
        }

        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
            return await _dbContext.Usuarios.AnyAsync(u => u.Email.Equals(email) && u.Ativo);
        }

    }
}
