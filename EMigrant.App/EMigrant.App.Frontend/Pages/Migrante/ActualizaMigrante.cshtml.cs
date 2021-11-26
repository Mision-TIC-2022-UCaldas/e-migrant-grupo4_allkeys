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
    public class ActualizaMigranteModel : PageModel
    {
        private readonly RepositorioMigrante _repositorioMigrante;
        [BindProperty]
        public Migrante Migrante { get; set; }

        public ActualizaMigranteModel(RepositorioMigrante repositorioMigrante)
        {

            this._repositorioMigrante = repositorioMigrante;
        }

        public IActionResult OnGet(int id)
        {
            Migrante = _repositorioMigrante.GetWithId(id);
            return Page();

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Migrante.id > 0)
            {
                Migrante = _repositorioMigrante.Update(Migrante);
            }
            return RedirectToPage("./Listar");
        }
    }
}
