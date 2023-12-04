using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcoShare.Areas.Identity.Data;
using EcoShare.Areas.Produto.Data;
using Microsoft.AspNetCore.Mvc;

namespace EcoShare.Areas.Fornecedor.Pages;
public class Fornecedor
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    [NotMapped]
    [BindProperty]
    [Display(Name = "Foto de Perfil")]
    [DataType(DataType.Upload)]
    public IFormFile FotoPerfil { get; set; }
    public string ImagemPerfilUrl { get; set; }
    public string Endereco { get; set; }
    public string HorarioAtendimento { get; set; }
    public DateTime DataAprovacao { get; set; }
    public string Descricao { get; set; }
    public string Whatsapp { get; set; }
    public string Instagram { get; set; }
    public List<DadosProduto> Produtos { get; set; }
    public Guid IdUsuario { get; set; }

    public Fornecedor()
    {

    }
    public Fornecedor(string nome, Guid idUsuario)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        IdUsuario = idUsuario;
    }
}