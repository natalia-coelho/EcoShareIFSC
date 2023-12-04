using EcoShare.Areas.Identity.Data;
using EcoShare.Areas.Produto.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EcoShare.Areas.Produto.Pages;

[Authorize(Roles = "Consumidor")]
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _dbContext;

    public IndexModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<DadosProduto> Produtos { get; set; }

    [BindProperty(SupportsGet = true)]
    public string SearchString { get; set; }

    // public void OnGet()
    // {
    //     Produtos = (from produto in _dbContext.Produtos.Take(10) select produto).ToList();
    // }

    // referencia: https://learn.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/search?view=aspnetcore-8.0
    public async Task OnGetAsync()
    {
        var produtos = from p in _dbContext.Produtos select p;

        if (!string.IsNullOrEmpty(SearchString))
        {
            produtos = produtos.Where(p => p.Nome.Contains(SearchString));
        }

        Produtos = await produtos.ToListAsync();
    }

}