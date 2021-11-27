using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EMigrant.App.Persistencia.AppRepositorios;
using EMigrant.App.Dominio;
using Microsoft.AspNetCore.Authorization;   



namespace MyApp.Namespace
{
       [Authorize]
    public class RegistroMigrante_Model : PageModel
    {
        private readonly RepositorioMigrante _repositorioMigrante;
        private readonly RepositorioFamiliares _repositorioFaminiliares;
        //private readonly RepositorioFamilias _repositorioFamilias;
        //private readonly RepositorioAmigos _repositorioAmigos; 
        [BindProperty]
        public Migrante Migrante { get; set; }

        public GrupoFamiliar grupoFamiliar { get; set;}

        //public Amigos Amigos { get; set; }
        //public Familias familias { get; set; }

        public RegistroMigrante_Model(RepositorioMigrante repositorioMigrante,RepositorioFamiliares repositorioFaminiliares)
        {

            this._repositorioMigrante = repositorioMigrante;
            this._repositorioFaminiliares = repositorioFaminiliares;
            //this._repositorioFamilias = repositorioFamilias;
            //this._repositorioAmigos = repositorioAmigos;
            grupoFamiliar = new GrupoFamiliar();
            //Amigos = new Amigos();
            //familias=new Familias();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Amigos=_repositorioAmigos.Create(Amigos);
            //familias=_repositorioFamilias.Create(familias);
            //grupoFamiliar.amigosId=Amigos.id;
            //grupoFamiliar.familiasId=familias.id;
            grupoFamiliar=_repositorioFaminiliares.Create(grupoFamiliar);
            Migrante.GrupoFamiliarId=grupoFamiliar.id;
            Migrante = _repositorioMigrante.Create(Migrante);

            Console.WriteLine(Migrante);

            return RedirectToPage("./Listar");
        }


    }
}
