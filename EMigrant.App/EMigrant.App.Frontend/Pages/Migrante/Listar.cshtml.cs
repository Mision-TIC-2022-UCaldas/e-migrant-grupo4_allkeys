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
    public class ListarModel : PageModel
    {
        private readonly RepositorioMigrante _repositorioMigrante;
        public IEnumerable<Migrante> Migrantes {get; set;}

        public ListarModel(RepositorioMigrante repositorioMigrante){

            this._repositorioMigrante= repositorioMigrante;
            
        }
        public void OnGet()
        {
            Migrantes = _repositorioMigrante.GetAll();
        }
    }
}
