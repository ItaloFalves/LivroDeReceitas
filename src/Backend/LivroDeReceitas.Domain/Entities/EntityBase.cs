namespace LivroDeReceitas.Domain.Entities
{
    public class EntityBase
    {
        public long Id { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }
}
