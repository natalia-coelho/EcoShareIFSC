using EcoShare.Areas.Identity.Data;
using EcoShare.Areas.Produto.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EcoShare.Areas.Produto.Pages;

public class ExcluirProdutoModel : PageModel
{
    private readonly ApplicationDbContext _dbContext;
    public ExcluirProdutoModel(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [BindProperty]
    public DadosProduto Produto { get; set; }
    public string MensagemErro { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid? id, bool? saveChangesError = false)
    {
        if (id is null)
        {
            return NotFound();
        }

        Produto = await _dbContext.Produtos
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == id);

        if (Produto is null)
        {
            return NotFound();
        }

        if (saveChangesError.GetValueOrDefault())
        {
            MensagemErro = $"Erro ao excluir produto {id}. Tente novamente";
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var produto = await _dbContext.Produtos.FindAsync(id);

        if (produto is null)
        {
            return NotFound();
        }

        try
        {
            _dbContext.Produtos.Remove(produto);
            await _dbContext.SaveChangesAsync();
            return RedirectToPage("./ListaProdutos");
        }
        catch (DbUpdateException ex)
        {
            return RedirectToAction("./Delete",
                                 new { id, saveChangesError = true });
        }
    }
}