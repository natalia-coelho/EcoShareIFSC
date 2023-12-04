using EcoShare.Areas.Identity.Data;
using EcoShare.Areas.Produto.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EcoShare.Areas.Produto.Pages
{
    public class AdicionarProdutoModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public AdicionarProdutoModel(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        [BindProperty]
        public DadosProduto Produto { get; set; }

        public IActionResult OnGet()
        {
            // For easy testing.
            Produto = new DadosProduto
            {

            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyProduct = new DadosProduto();

            if (await TryUpdateModelAsync<DadosProduto>(
                emptyProduct,
                "produto",   // Prefix for form value.
                s => s.Nome, s => s.Descricao, s => s.Preco, s => s.Estoque, s => s.Categoria, s => s.Fornecedor,  s => s.UrlImagem))
            {
                // var existingSupplier = _dbContext.Fornecedores.FirstOrDefault(f => f.Id == emptyProduct.Fornecedor.Id);

                // if (existingSupplier == null)
                //     _dbContext.Fornecedores.Add(emptyProduct.Fornecedor);
                // else
                //     emptyProduct.Fornecedor = existingSupplier;

                _dbContext.Produtos.Add(emptyProduct);
                await _dbContext.SaveChangesAsync();
                return RedirectToPage("./ListaProdutos");
            }

            return Page();
        }
    }
}
