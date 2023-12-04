using EcoShare.Areas.Identity.Data;
using EcoShare.Areas.Produto.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoShare.Areas.Produto.Pages;

[Authorize(Roles = "Fornecedor Aprovado")]
public class ListaProdutosModel : PageModel
{
    private readonly ApplicationDbContext _dbContext;

    public ListaProdutosModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<DadosProduto> Produtos { get; set; }

    public void OnGet()
    {
        // DadosProduto produto = new DadosProduto
        // {
        //     Nome = "Teste"
        // };

        // _dbContext.Produtos.Add(produto);
        // _dbContext.SaveChanges();
        
        Produtos = (from produto in _dbContext.Produtos.Take(3) select produto).ToList();
    }

}