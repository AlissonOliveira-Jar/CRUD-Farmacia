using CRUD_Farmacia.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Farmacia.DataAccess
{
    public class DataAccess
    {
        public class FarmaciaContext : DbContext
        {
            private IConfiguration _configuration;

            public FarmaciaContext(IConfiguration configuration)
            {
                _configuration = configuration;
            }

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
                var typeDatabase = _configuration["TypeDatabase"];
                var connectionString = _configuration.GetConnectionString(typeDatabase);

                if (typeDatabase == "SqlServer")
                {
                    optionsBuilder.UseSqlServer(connectionString);
                }
            }
        }
    }
}
