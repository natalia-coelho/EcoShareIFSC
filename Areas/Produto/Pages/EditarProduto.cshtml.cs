using EcoShare.Areas.Identity.Data;
using EcoShare.Areas.Produto.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoShare.Areas.Produto.Pages;

public class EditarProdutoModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditarProdutoModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public DadosProduto Produto { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Produto = await _context.Produtos.FindAsync(id);

        if (Produto == null)
        {
            return NotFound();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid id)
    {
        var produtoParaAtualizar = await _context.Produtos.FindAsync(id);

        if (produtoParaAtualizar == null)
        {
            return NotFound();
        }

        if (await TryUpdateModelAsync<DadosProduto>(
            produtoParaAtualizar,
            "produto",
            p => p.Nome, p => p.Descricao, p => p.Preco, p => p.Estoque, p => p.Categoria, p => p.Fornecedor, p => p.UrlImagem))
        {
            await _context.SaveChangesAsync();
            return RedirectToPage("./ListaProdutos");
        }

        return Page();
    }
}