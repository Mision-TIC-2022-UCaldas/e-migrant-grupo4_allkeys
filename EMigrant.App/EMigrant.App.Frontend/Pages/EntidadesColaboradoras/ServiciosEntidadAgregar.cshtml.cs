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
    public class ServiciosEntidadAgregarModel : PageModel
    {
        private readonly RepositorioServicio _repoServicios;
        private readonly RepositorioEntidades _repoEntidades;
        [BindProperty]
        public Servicio Servicio {get; set;}
        public EntidadColaboradora Entidad {get; set;}
        public ServiciosEntidadAgregarModel(RepositorioServicio _repoServicios, RepositorioEntidades _repoEntidades)
        {
            this._repoServicios = _repoServicios;
            this._repoEntidades = _repoEntidades;
        }

        public void OnGet(int id)
        {
            Entidad = _repoEntidades.GetWithId(id);
        }

        public IActionResult OnPost(int id)
        {
            if(ModelState.IsValid)
            {
                Servicio.EntidadId = id;
                Servicio = _repoServicios.Create(Servicio);
                return RedirectToPage("./ServiciosEntidad", new {id = id});
            }
            return Page();
        }
    }
}
