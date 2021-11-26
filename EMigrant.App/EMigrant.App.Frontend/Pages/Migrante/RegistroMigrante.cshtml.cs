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
    public class RegistroMigrante_Model : PageModel
    {
        private readonly RepositorioMigrante _repositorioMigrante;
        [BindProperty]
        public Migrante Migrante { get; set; }

        public RegistroMigrante_Model(RepositorioMigrante repositorioMigrante)
        {

            this._repositorioMigrante = repositorioMigrante;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Migrante = _repositorioMigrante.Create(Migrante);
            Console.WriteLine(Migrante);

            return RedirectToPage("../Index");
        }


    }
}
