using EcoShare.Areas.Identity.Data;
using EcoShare.Areas.Produto.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoShare.Areas.Fornecedor.Pages;
public class VisualizarFornecedor : PageModel
{
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }
    private readonly ApplicationDbContext _dbContext;
    public Fornecedor Fornecedor;
    public List<DadosProduto> Produtos;

    public VisualizarFornecedor(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void OnGet(Guid id)
    {
        Fornecedor = _dbContext.Fornecedores.Find(id);
        Produtos = _dbContext.Produtos.Where(o => o.Fornecedor == Fornecedor).ToList();
        Fornecedor.Produtos = Produtos;
    }
}