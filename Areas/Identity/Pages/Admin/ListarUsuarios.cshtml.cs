using System.ComponentModel.DataAnnotations;
using EcoShare.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoShare.Areas.Identity.Pages.Admin;

[Authorize(Roles = "Administrador")]
public class ListarUsuariosModel : PageModel
{
    private readonly UserManager<Usuario> _userManager;
    public List<Usuario> TodosUsuarios { get; set; }

    public ListarUsuariosModel(UserManager<Usuario> userManager)
    {
        _userManager = userManager;
    }
    public void OnGet()
    {
        var users = _userManager.Users.ToList();

        TodosUsuarios = users.OrderByDescending(User => User.TipoUsuario).ToList();
    }
}
