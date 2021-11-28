using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EMigrant.App.Persistencia.AppRepositorios;

namespace MyApp.Namespace
{
    public class BorrarFamiliarModel : PageModel
    {
        private readonly RepositorioParientes _repoPariente;

        public BorrarFamiliarModel(RepositorioParientes repoPariente)
        {
            this._repoPariente = repoPariente;
        }
        public IActionResult OnGet(int id, int idUsuario)
        {
            _repoPariente.Delete(id);
            return RedirectToPage("./ListarGrupo", new {id = idUsuario});
        }

    }
}
