using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EMigrant.App.Persistencia.AppRepositorios;

namespace MyApp.Namespace
{
    public class BorrarAmigoModel : PageModel
    {
         private readonly RepositorioAmigos _repoAmigos;

        public BorrarAmigoModel(RepositorioAmigos repoAmigos)
        {
            this._repoAmigos = repoAmigos;
        }
        public IActionResult OnGet(int id, int idUsuario)
        {
            Console.WriteLine(id);
            Console.WriteLine(idUsuario);
            _repoAmigos.Delete(id);
            return RedirectToPage("./ListarGrupo", new {id = idUsuario});
        }
    }
}
