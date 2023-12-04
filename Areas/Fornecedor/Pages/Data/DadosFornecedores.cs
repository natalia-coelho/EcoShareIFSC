using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcoShare.Areas.Identity.Data;
using EcoShare.Areas.Produto.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoShare.Areas.Fornecedor.Pages;
public class DadosFornecedores : PageModel
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
    private readonly ApplicationDbContext _dbContext;

    public DadosFornecedores(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void OnGet()
    {
        Fornecedor fornecedor = new Fornecedor(
            nome: "Fornecedor Aprovado",
            idUsuario: Guid.Parse("f53bc00a-0207-477d-9426-a25a3bc9e183")
        );

        _dbContext.Fornecedores.Add(fornecedor);
        _dbContext.SaveChanges();
        // Preencha os dados do fornecedor e produtos a partir de alguma fonte de dados,
        // como um banco de dado s ou serviço web.
        // Exemplo:
        Nome = "Batata Corp";
        Endereco = "Rua das ruas, 1000";
        HorarioAtendimento = "08h00 às 19h30";
        DataAprovacao = DateTime.Now;
        Descricao = "Bem-vindo ao Delícias da Batata, o seu destino gastronômico especializado em batatas. Aqui, nossa paixão pelas batatas se transforma em pratos irresistíveis que irão satisfazer os amantes desse versátil tubérculo. Somos dedicados a criar uma experiência culinária única, onde a batata é a estrela do cardápio.";
        Produtos = new List<DadosProduto>
        {
            new DadosProduto { Nome = "Produto 1", Descricao = "Descrição do Produto 1", UrlImagem = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRRAgrE9NE7a_dcMWoixyMti-7X8Amg7x64MA&usqp=CAU" },
            new DadosProduto { Nome = "Produto 2", Descricao = "Descrição do Produto 2", UrlImagem = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuD-VvIij03GQCEokk_oBhQBvSzZFEzYhWxA&usqp=CAU" },
            new DadosProduto { Nome = "Produto 3", Descricao = "Descrição do Produto 3", UrlImagem = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcROtRowrYwgxwITXADjvy0aOZ2l5nMBRAr1nJQEEu4-aRRXIfkXnJJSc2WRlEHWDiZwOrs&usqp=CAU" },
            new DadosProduto { Nome = "Produto 4", Descricao = "Descrição do Produto 4", UrlImagem = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR0NVybGRrTlMVVXx0BJaKaEvADcQwUr7Dplw&usqp=CAU" },
            new DadosProduto { Nome = "Produto 5", Descricao = "Descrição do Produto 5", UrlImagem = "data:image/jpeg;base64,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" },
            // Adicione mais produtos conforme necessário
        };
    }
    public async Task<IActionResult> OnPostAsync()
    {

        if (ModelState.IsValid)
        {
            if (this.FotoPerfil != null && this.FotoPerfil.Length > 0)
            {
                // Lógica para salvar a foto no servidor (por exemplo, em uma pasta)
                // Certifique-se de tratar exceções e validar o tipo de arquivo conforme necessário.
                var filePath = Path.Combine("C:\\dev\\projects\\EcoShare\\wwwroot\\img", FotoPerfil.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await FotoPerfil.CopyToAsync(stream);
                }
            }

            return RedirectToPage("./EditarPerfilPublico");
        }

        return Page();
    }
}


