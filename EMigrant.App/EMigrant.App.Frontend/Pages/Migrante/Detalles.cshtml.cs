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
    public class DetallesModel : PageModel
    {
        private readonly RepositorioMigrante _repositorioMigrante;
        
        
        public Migrante Migrante {get; set;}
        public bool MigranteEncontrado {get; set;}

        public DetallesModel(RepositorioMigrante repositorioMigrante)
        {
            this._repositorioMigrante = repositorioMigrante;
            MigranteEncontrado= false;
        }
        public IActionResult OnGet(int id)
        {
            Migrante = _repositorioMigrante.GetWithId(id);
            if(Migrante==null){
                MigranteEncontrado = false;
                return Page();
            }
            MigranteEncontrado = true;
            return Page();
        }
    }
}
