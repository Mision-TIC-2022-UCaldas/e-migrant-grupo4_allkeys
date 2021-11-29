using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EMigrant.App.Dominio;
using EMigrant.App.Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EMigrant.App.Frontend.EntidadesColaboradoras
{
    public class AgregarModel : PageModel
    {
        private readonly RepositorioEntidades _repoEntidades;
        //[BindProperty]
        //public string Sector {get; set;}
        [BindProperty]
        public EntidadColaboradora Entidad {get; set;}
        public bool nitRepetido {get; set;}
        public AgregarModel(RepositorioEntidades _repoEntidades)
        {
            this._repoEntidades = _repoEntidades;
            nitRepetido = false;
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                if(!_repoEntidades.VerificarExistenciaNit(Entidad.Nit))
                {
                    Entidad = _repoEntidades.Create(Entidad);
                    return RedirectToPage("./Lista");
                }
                nitRepetido = true;
            }
            return Page();
        }
    }
}