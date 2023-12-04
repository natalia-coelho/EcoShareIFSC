using EcoShare.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoShare.Areas.Fornecedor.Pages;

[Authorize(Roles = "Consumidor")]
public class ListaFornecedorModel : PageModel
{
    private readonly ApplicationDbContext _dbContext;

    public ListaFornecedorModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Fornecedor> Fornecedor { get; set; }

    public void OnGet()
    {
        // DadosProduto produto = new DadosProduto
        // {
        //     Nome = "Teste"
        // };

        // _dbContext.Fornecedores.Add(produto);
        // _dbContext.SaveChanges();
        // Fornecedor = (from fornecedor in _dbContext.Fornecedores.Take(10) select fornecedor).ToList();
        Fornecedor = (from fornecedor in _dbContext.Fornecedores.Take(50) select fornecedor).ToList();

    }

    // public async Task OnGetAsync()
    // {
    //     var fornecedores = from f in _dbContext.Fornecedores select f;

    //     if (!string.IsNullOrEmpty(SearchString))
    //     {
    //         fornecedores = fornecedores.Where(f => f.Nome.Contains(SearchString));
    //     }

    //     Fornecedor = await fornecedores.ToListAsync();
    // }

}