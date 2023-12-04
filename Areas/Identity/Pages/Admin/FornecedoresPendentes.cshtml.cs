using System.ComponentModel.DataAnnotations;
using EcoShare.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoShare.Areas.Identity.Pages.Admin;

[Authorize(Roles = "Administrador")]
public class FornecedoresPendentesModel : PageModel
{
    private readonly UserManager<Usuario> _userManager;
    public List<Usuario> FornecedoresPendentes { get; set; }
    public List<Usuario> FornecedoresAprovados { get; set; }

    public FornecedoresPendentesModel(UserManager<Usuario> userManager)
    {
        _userManager = userManager;
    }


    public void OnGet()
    {
        var users = _userManager.Users.ToList();
        FornecedoresPendentes = users.Where(user => _userManager.IsInRoleAsync(user, "Fornecedor Pendente").Result).ToList();
        FornecedoresAprovados = users.Where(user => _userManager.IsInRoleAsync(user, "Fornecedor Aprovado").Result).ToList();
    }

    public async Task<IActionResult> OnPostAprovarFornecedor(string username)
    {
        // achar usuario
        var user = _userManager.Users.Where(user => user.UserName == username).FirstOrDefault();

        if (user == null) return Page();

        await _userManager.AddToRoleAsync(user, "Fornecedor Aprovado");

        // remover role pendente
        await _userManager.RemoveFromRoleAsync(user, "Fornecedor Pendente");

        return RedirectToPage();
    }
}
