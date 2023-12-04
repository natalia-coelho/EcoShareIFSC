using EcoShare.Areas.Fornecedor.Pages;
using EcoShare.Areas.Identity.Data;

namespace EcoShare.Areas.Produto.Data;

// Chamando essa classe de DadosProduto porque se chamasse de Produto iria dar erro pois é o nome do namespace
public class DadosProduto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public string UrlImagem { get; set; }
    public string Descricao { get; set; }
    public string Estoque { get; set; }
    public string Categoria { get; set; }
    public Fornecedor.Pages.Fornecedor Fornecedor { get; set; }
}