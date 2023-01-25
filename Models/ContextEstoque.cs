using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace SistemaEstoque.Models
{
    public class ContextEstoque : DbContext
    {
        public DbSet<EstoqueModel> Estoques { get; set; }
        public ContextEstoque(DbContextOptions<ContextEstoque> opcoes) : base(opcoes)
        {
            
        }   
    }
}
