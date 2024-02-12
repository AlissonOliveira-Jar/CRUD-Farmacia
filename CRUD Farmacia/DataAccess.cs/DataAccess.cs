using CRUD_Farmacia.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Farmacia.DataAccess
{
    public class DataAccess
    {
        public class FarmaciaContext : DbContext
        {
            public DbSet<Loja> Lojas { get; set; }
            public DbSet<Produto> Produtos { get; set; }
            public DbSet<Estoque> Estoques { get; set; }
            public DbSet<Preco> Precos { get; set; }
            public DbSet<Usuario> Usuarios { get; set; }
            public DbSet<Desconto> Descontos { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Usuario>()
                    .HasMany(u => u.Descontos)
                    .WithMany(d => d.Usuarios);
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Farmacia;Integrated Security=True");
            }
        }
    }
}
