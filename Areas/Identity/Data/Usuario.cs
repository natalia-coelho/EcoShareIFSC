using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EcoShare.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Usuario class
[Keyless]
public class Usuario : IdentityUser
{
        [PersonalData]
        public string Nome { get; set; }
        [PersonalData]
        public string NumeroTelefone { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
}

