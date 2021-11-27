using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EMigrant.App.Persistencia.AppRepositorios;
using EMigrant.App.Dominio;

namespace MyApp.Namespace
{
    public class ListarGrupoModel : PageModel
    {
        private readonly RepositorioMigrante _repositorioMigrante;
        private readonly RepositorioFamiliares _repositorioFaminiliares;
        public Migrante Migrante { get; set; }
        public IEnumerable<Migrante> Familiares { get; set; }

        public ListarGrupoModel(RepositorioFamiliares repositorioFaminiliares, RepositorioMigrante repositorioMigrante)
        {

            this._repositorioMigrante = repositorioMigrante;
            this._repositorioFaminiliares = repositorioFaminiliares;


        }

        // public IEnumerable<Migrante> GetFamiliares()
        // {
        //     return Migrante.GrupoFamiliar.Familiares;
        // }

        public IActionResult OnGet(int id, IEnumerable<Migrante> familiares)
        {
            if (id > 0)
            {
                Migrante = _repositorioMigrante.GetWithId(id);
                Familiares = familiares;
                
                
                return Page();
            }
            return RedirectToPage("../Migrante/Listar");


        }
    }
}
