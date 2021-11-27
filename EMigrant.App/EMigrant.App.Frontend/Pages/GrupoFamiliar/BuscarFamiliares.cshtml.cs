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
    public class BuscarFamiliaresModel : PageModel
    {
        private readonly RepositorioMigrante _repositorioMigrante;
        private readonly RepositorioFamiliares _repositorioFaminiliares;
         public Migrante Migrante { get; set; }
         public bool familiarEncontrado { get; set; }
         public string textoFiltro { get; set; }
        public BuscarFamiliaresModel(RepositorioFamiliares repositorioFaminiliares, RepositorioMigrante repositorioMigrante)
        {
            this._repositorioMigrante = repositorioMigrante;
            this._repositorioFaminiliares = repositorioFaminiliares;
            familiarEncontrado=false;
        }
        public IActionResult OnGet(String textoFiltro){
            Console.WriteLine(textoFiltro);
            
            if(!String.IsNullOrEmpty(textoFiltro)){
                Migrante=_repositorioMigrante.GetWithDoc(textoFiltro);
                if(Migrante != null){
                    Console.WriteLine(familiarEncontrado);
                    familiarEncontrado=true;
                    //return Page();
                }else{
                    familiarEncontrado=false;
                }
            }
            return Page();
        }
    }
}
