using System;

public class FarmaciaContext : DbContext
{
    public DbSet<Loja> Lojas { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Estoque> Estoques { get; set; }
    public DbSet<Preco> Precos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Farmacia;Integrated Security=True");
    }
}
