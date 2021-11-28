using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMigrant.App.Dominio;
using EMigrant.App.Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EMigrant.App.Frontend.EntidadesColaboradoras
{
    public class DetallesModel : PageModel
    {
        private readonly RepositorioEntidades _repositorioEntidades;
        
        
        public EntidadColaboradora Entidad {get; set;}
        public bool EntidadEncontrada {get; set;}
        public int id {get; set;}

        public DetallesModel(RepositorioEntidades repositorioEntidades)
        {
            this._repositorioEntidades = repositorioEntidades;
            EntidadEncontrada= false;
        }
        public IActionResult OnGet(int id)
        {
            this.id = id;
            Entidad = _repositorioEntidades.GetWithId(id);
            if(Entidad==null){
                EntidadEncontrada = false;
                return Page();
            }
            EntidadEncontrada = true;
            return Page();
        }
    }
}
