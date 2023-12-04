using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EcoShare.Areas.Produto.Data;
using EcoShare.Areas.Fornecedor.Pages;


namespace EcoShare.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<Usuario>
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<DadosProduto> Produtos { get; set; }
    public DbSet<Fornecedor.Pages.Fornecedor> Fornecedores { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
